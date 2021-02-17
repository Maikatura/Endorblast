using Endorblast.GameServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Nez;
using Nez.AI.BehaviorTrees;
using GameTime = Microsoft.Xna.Framework.GameTime;

namespace Endorblast.GameServer
{
    class GameLogic
    {
        
        private static GameLogic instance = new GameLogic();
        public static GameLogic Instance => instance;

        
        
        
        
        public void Update()
        {
            
            
            // Main Logic
            MapManager.Instance.Update();
            
            
            // Debug Stuff
            //Console.WriteLine();
            

        }
        
        
       
    }
}
