using EndorblastCore.Lib;
using Nez;
using System;

namespace EndorblastCore
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            
            using (var game = new Game1())
                game.Run();
            
            


            
        }
    }
}