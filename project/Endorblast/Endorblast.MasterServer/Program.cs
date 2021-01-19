using System;

namespace Endorblast.MasterServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BCrypt.Net.BCrypt.HashPassword("123"));
            
            
            MasterServerScript.Instance.Start();
        }
    }
}
