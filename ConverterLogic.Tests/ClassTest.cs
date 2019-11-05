using LogicConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ConverterLogic.Tests
{
    [TestClass]
    public class ClassTest
    {
        [TestMethod]
        public void TestRecupTexte()
        {
            //Act
            SpeechToText speechToText = new SpeechToText();
            //Arrange
            var texte = speechToText.ConvertAudio(@"C:\Users\Ambroise\Downloads\audio-file2.flac");
            //Assert
            //Assert.AreEqual("200", texte.StatusCode);
            Assert.AreEqual("a line of severe thunderstorms with several possible tornadoes is approaching Colorado on Sunday ", texte.Content);
            //Assert.ThrowsException<IBM.Cloud.SDK.Core.Http.Exceptions.ServiceResponseException>(() => speechToText.Convert());
        }

        [TestMethod]
        public void BadPath()
        {
            //Act
            SpeechToText speechToText = new SpeechToText();
            //Arrange
            var path = @"C:\Users\Ambroise\Doc\Downloads\audio-file2.flac";
            //Assert
            Assert.ThrowsException<InvalidFilePathException>(() => speechToText.ConvertAudio(path));
        }

        [TestMethod]
        public void BadExtension()
        {
            //Act
            SpeechToText speechToText = new SpeechToText();
            //Arrange
            var path = @"C:\Users\Ambroise\Downloads\audio-file2.core";
            //Assert
            Assert.ThrowsException<UnavailableExtensionException>(() => speechToText.ConvertAudio(path));
        }

        [TestMethod]
        public void StreamConvert()
        {
            //Act
            StreamingAudioToText audioToText = new StreamingAudioToText();
            //Arrange
            StreamingAudioToText.Transcribe();
            //Assert
            //Assert.ThrowsException<UnavailableExtensionException>(() => speechToText.ConvertAudio(path));
        }
    }
}
