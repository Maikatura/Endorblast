using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Lib
{
    public class ClientSettings : IUpdatable
    {

        // -- Server Settings -- //
        public static string serverAddress = "localhost";
        public static int loginPort = 5555;
        public static int gamePort = 5556;

        public static int tickRate = 1;
        public static float updateRate = 1 / tickRate;
        public static float updateTime = 1 / tickRate;

        public static bool isClient = true;

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public void Update()
        {
            if (updateTime <= 0)
            {
                updateTime = updateRate;
            }
            else
            {
                updateTime -= Time.DeltaTime;
            }
        }
    }
}
