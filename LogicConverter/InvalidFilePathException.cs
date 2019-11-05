using System;
using System.Runtime.Serialization;

namespace LogicConverter
{
    [Serializable]
    public class InvalidFilePathException : Exception
    {
        private static string message = "Désolé, le chemin saisi ne mène à aucun fichier.";
        public InvalidFilePathException() : base(message)
        {
        }
    }
}