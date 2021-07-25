using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.GameServer;
using Endorblast.Library;
using Endorblast.Library.Entities;
using Endorblast.Library.GameObjects;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;

namespace Endorblast.GameServer.Entities
{
    public class Player : Component, IUpdatable
    {
        
        
        public string AccountName;
        public string CharacterName;
        public int currentLobbyId;
        public int playerID;
        public int WorldID;
        public NetConnection connection;


        public override void OnAddedToEntity()
        {
            
        }

        public Player(NetConnection con)
        {
            connection = con;
            Console.WriteLine("Created Entity");
        }

        
        
        
        public void Update()
        {
           

            
        }


        


        
        
        
    }
}