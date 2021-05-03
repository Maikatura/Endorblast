using System;
using System.Drawing;

namespace Endorblast.Library
{
    public enum ServerErrors
    {
        Error,
        Success,
        Info,
        None,
    }
    
    public class ConsoleHelper
    {
        
        

        public static ConsoleColor GetColor(ServerErrors type)
        {
            switch (type)
            {
                case ServerErrors.Success:
                    return ConsoleColor.Green;
                case ServerErrors.Error:
                    return ConsoleColor.Red;
                case ServerErrors.Info:
                    return ConsoleColor.Yellow;
            }
            
            return ConsoleColor.DarkYellow;
        }


        public static string StringType(ServerErrors type)
        {
            switch (type)
            {
                case ServerErrors.Info:
                    return "#";
                case ServerErrors.Success:
                    return "##";
                case ServerErrors.Error:
                    return "###";
            }

            return "";
        }
        

        public static void WriteLine(string text, ServerErrors type = ServerErrors.None)
        {
            var color = GetColor(type);
            var debugString = StringType(type);
            var writeText = $"{debugString} {text}";
            
            Console.ForegroundColor = color;
            Console.WriteLine(writeText);
            Console.ForegroundColor = GetColor(ServerErrors.None);
        }
        
        public static void Write(string text, ServerErrors type = ServerErrors.None)
        {
            var color = GetColor(type);
            var debugString = StringType(type);
            var writeText = $"{debugString} {text}";
            
            Console.ForegroundColor = color;
            Console.Write(writeText);
            Console.ForegroundColor = GetColor(ServerErrors.None);
        }
        
    }
}