using System;
using System.Collections.Generic;
using System.Text;
using KaymakNetwork;
using System.Threading;

namespace MasterServer
{




    class MainServer
    {

        // Init - Making the server (Loading everything in before starting)
        public void Init(int port, int maxPlayers)
        {
            NetworkConfig.InitNetwork();
            NetworkConfig.Socket.StartListening(port, 5, 1);
        }

        public void Start()
        {
            Thread serverLoop = new Thread(new ThreadStart(ServerUpdateLoop));
            serverLoop.Start();
        }

        private static void ServerUpdateLoop()
        {
            DateTime now = DateTime.Now;

            while (true)
            {
                while (now < DateTime.Now)
                {
                    GameLogic.Update();

                    now = now.AddMilliseconds(ServerSettings.MS_PER_TICK);

                    if (now > DateTime.Now)
                    {
                        try
                        {
                            Thread.Sleep(now - DateTime.Now);
                        }
                        catch
                        {

                        }
                    }
                }
            }

        }

    }
}
