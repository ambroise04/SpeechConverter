using System;
using System.Runtime.Serialization;

namespace LogicConverter
{
    [Serializable]
    public class UnavailableExtensionException : Exception
    {
        private static string message = "L'extension du fichier n'est pas prise en compte.";
        public UnavailableExtensionException() : base(message)
        {
            
        }
    }
}