using System;
using System.Drawing;

namespace Endorblast.GameServer
{
    public enum ServerErrors
    {
        Error,
        Success,
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
                case ServerErrors.None:
                    return ConsoleColor.DarkYellow;
                default:
                    return ConsoleColor.DarkYellow;
            }
        }

        public static void WriteLine(string text, ServerErrors type)
        {
            var color = GetColor(type);

            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = GetColor(ServerErrors.None);
        }
        
        public static void Write(string text, ServerErrors type)
        {
            var color = GetColor(type);

            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = GetColor(ServerErrors.None);
        }
        
    }
}