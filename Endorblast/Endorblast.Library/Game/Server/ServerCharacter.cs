using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Library.GameObjects;
using Endorblast.Library.Entities;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;

namespace Endorblast.Library
{
    public class ServerCharacter
    {
        public string AccountName;
        public string CharacterName;
        public int currentLobbyId;
        public int playerID;
        public int WorldID;
        public NetConnection connection;

        public float X;
        public float Y;
        public MoveState State;
        
        public TiledMapMover mover;
        public TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        public BoxCollider boxCollider;

        public Vector2 velocity;

        public void Update()
        {
            // Todo : Validate everything the player does!
            Console.WriteLine("LOL");
            
            
            
            
            
            
        }


        public void SetPosition(float x, float y, MoveState state)
        {
            X = x;
            Y = y;
            State = state;
        }


        public void SetMap()
        {
            
        }
        
        public StaticCharacter ToStaticCharacter()
        {
            var lc = new StaticCharacter();

            lc.connection = this.connection;
            lc.Name = this.AccountName;
            lc.PlayerID = this.playerID;
            lc.WorldID = this.WorldID;

            return lc;
        }
    }
}
