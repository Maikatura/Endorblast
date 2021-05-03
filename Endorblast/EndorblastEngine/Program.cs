using Endorblast.Library;
using Nez;
using System;

namespace Endorblast
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