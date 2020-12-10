using EndorblastCore.GameServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using System.Text;
using System.Threading;
using Nez.AI.BehaviorTrees;
using GameTime = Microsoft.Xna.Framework.GameTime;

namespace EndorblastCore.GameServer
{
    class GameLogic
    {
        
        private static GameLogic instance = new GameLogic();
        public static GameLogic Instnace => instance;
        
        private GameTime gameTime;
        private Stopwatch timer;
        private TimeSpan elapsed;

        private long frameCounter = 0;
        
        public void Init()
        {
            if (timer == null) timer = Stopwatch.StartNew();
            
            Thread threadConsole = new Thread(new ThreadStart(Update));
            threadConsole.Start();
        }
        
        private void Update()
        {
            while (true)
            {
                gameTime = new GameTime(timer.Elapsed, timer.Elapsed - elapsed);
                elapsed = timer.Elapsed;
                
                // Update loop for everything that needs to be updated.
                MapManager.Instance.Update(gameTime);
                
                // Debug Test (DeltaTime)
                //Console.WriteLine($"Test: {gameTime.ElapsedGameTime}");
                frameCounter++;
            }

            

        }
        
        
       
    }
}
