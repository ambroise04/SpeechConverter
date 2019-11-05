using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogicConverter
{
    public class StreamingAudioToText
    {
        private static string User;
        private static string Password;

        static readonly string file = @"c:\audio.wav";

        static readonly Uri url = new Uri("wss://https://gateway-lon.watsonplatform.net/speech-to-text/api");

        // these should probably be private classes that use DataContractJsonSerializer 
        // see https://msdn.microsoft.com/en-us/library/bb412179%28v=vs.110%29.aspx
        // or the ServiceState class at the end
        static ArraySegment<byte> openingMessage = new ArraySegment<byte>(Encoding.UTF8.GetBytes(
            "{\"action\": \"start\", \"content-type\": \"audio/wav\", \"continuous\" : true, \"interim_results\": true}"
        ));
        static ArraySegment<byte> closingMessage = new ArraySegment<byte>(Encoding.UTF8.GetBytes(
            "{\"action\": \"stop\"}"
        ));

        public StreamingAudioToText()
        {
            User = "Auto-generated service credentials";
            Password = "YuGYo0MhAKMBJJ1W4ofcvqzN5PCx2c_7C7OBXYyvPSlB";
        }
        public StreamingAudioToText(string User, string Password)
        {
            StreamingAudioToText.User = User;
            StreamingAudioToText.Password = Password;
        }

        public static void Transcribe()
        {
            using (ClientWebSocket clientWebSocket = new ClientWebSocket())
            {
                clientWebSocket.Options.Credentials = new NetworkCredential(User, Password);
                

                clientWebSocket.ConnectAsync(url, CancellationToken.None).Wait();

                // send opening message and wait for initial delimeter 
                Task.WaitAll(clientWebSocket.SendAsync(openingMessage, WebSocketMessageType.Text, true, CancellationToken.None), HandleResults(clientWebSocket));

                // send all audio and then a closing message; simltaneously print all results until delimeter is recieved
                Task.WaitAll(SendAudio(clientWebSocket), HandleResults(clientWebSocket));

                // close down the websocket
                clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Close", CancellationToken.None).Wait();
            }
        }

        static async Task SendAudio(ClientWebSocket ws)
        {
            using (FileStream fs = File.OpenRead(file))
            {
                byte[] b = new byte[1024];
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    await ws.SendAsync(new ArraySegment<byte>(b), WebSocketMessageType.Binary, true, CancellationToken.None);
                }
                await ws.SendAsync(closingMessage, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        // prints results until the connection closes or a delimeterMessage is recieved
        static async Task HandleResults(ClientWebSocket ws)
        {
            var buffer = new byte[1024];
            while (true)
            {
                var segment = new ArraySegment<byte>(buffer);

                var result = await ws.ReceiveAsync(segment, CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    return;
                }

                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        await ws.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None);
                        return;
                    }

                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = await ws.ReceiveAsync(segment, CancellationToken.None);
                    count += result.Count;
                }

                var message = Encoding.UTF8.GetString(buffer, 0, count);

                // you'll probably want to parse the JSON into a useful object here,
                // see ServiceState and IsDelimeter for a light-weight example of that.
                Console.WriteLine(message);

                if (IsDelimeter(message))
                {
                    return;
                }
            }
        }

        // the watson service sends a {"state": "listening"} message at both the beginning and the *end* of the results
        // this checks for that
        [DataContract]
        internal class ServiceState
        {
            [DataMember]
            public string state = "";
        }
        static bool IsDelimeter(String json)
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ServiceState));
            ServiceState obj = (ServiceState)ser.ReadObject(stream);
            return obj.state == "listening";
        }
    }
}
