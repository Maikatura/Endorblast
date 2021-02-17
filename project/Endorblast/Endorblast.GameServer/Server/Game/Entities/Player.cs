using Lidgren.Network;
using System;
using Endorblast.Lib.Enums;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;

namespace Endorblast.GameServer.Entities
{
    public class Player : Component, IUpdatable
    {
        
        
        private Vector2 position;
        
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
        
        public float moveSpeed = 100;
        public float defaultSpeed = 100;
        public float sprintSpeed = 250;
        public float gravity = 1000;
        public float jumpHeight = 16 * 7;


        public override void OnAddedToEntity()
        {
            
            boxCollider = Entity.AddComponent(new BoxCollider(16, 64));
        }

        public Player()
        {
            
            
            
            position = new Vector2(0, 0);
            velocity = new Vector2(0, 0);
            
            Console.WriteLine("Created Entity");
        }

        public void SetMap(TmxLayer groundlayer)
        {
            mover = new TiledMapMover(groundlayer);
        }
        
        
        public void Update()
        {
            // Todo : Validate everything the player does!

            velocity.X = moveSpeed;
            velocity.Y += gravity * Time.DeltaTime;
            mover.Move(velocity * Time.DeltaTime, boxCollider, collisionState);

            if (collisionState.Right || collisionState.Left)
            {
                velocity.X = 0;
            }

            if (collisionState.Below || collisionState.Above)
            {
                velocity.Y = 0;
            }

        }


        


        
        
        
    }
}