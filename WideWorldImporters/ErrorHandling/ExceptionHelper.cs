using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization;

namespace WideWorldImporters.ErrorHandling
{
    public class ExceptionHelper
    {
        public static string GetFileNotFoundExplanation(FileNotFoundException ex)
        {
            string explanation = "The following error occured:";
            explanation += "The file" + ex.FileName + " Could not be found." + ex.Message;

            return explanation;
        }

        public static string GetFileReadExplanation(IOException ex)
        {
            string explanation = "The following error occured:";
            explanation += "The file" + ex.GetType().Name + " Could not be read and load." + ex.Message;

            return explanation;
        }

        public static string GetSerializationExplanation(SerializationException ex)
        {
            string explanation = "The following error occured:";
            explanation += "Error with serialization/Deserialization object ParentsChildren" + ex.Message;

            return explanation;
        }
    }
}