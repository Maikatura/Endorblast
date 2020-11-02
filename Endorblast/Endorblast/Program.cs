using System;


namespace Endorblast
{
    /// <summary>
    /// The main class.
    /// </summary>
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
