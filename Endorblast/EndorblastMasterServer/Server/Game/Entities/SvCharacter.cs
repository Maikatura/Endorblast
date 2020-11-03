using Endorblast;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib;

namespace EndorblastServer
{
    public class BasePlayer : Component, IUpdatable
    {
        public string Name;
        public bool isInGame;
        public int currentLobbyId;
        public int WorldID;
        public NetConnection connection;


        float moveSpeed = 100;
        float defaultSpeed = 100;
        float sprintSpeed = 250;
        float gravity = 1000;
        float jumpHeight = 16 * 7;

        TiledMapMover mover;
        TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        BoxCollider boxCollider;
        Vector2 velocity;


        KeyboardInput keys = new KeyboardInput();

        public BasePlayer() { }

        public BasePlayer(string name, NetConnection con)
        {
            this.Name = name;
            this.connection = con;
            isInGame = true;
        }

        public override void OnAddedToEntity()
        {
            mover = this.AddComponent(new TiledMapMover());
        }

        

        public void Update()
        {
            if (keys.isSprinting)
            {
                moveSpeed = sprintSpeed;
            }
            else
            {
                moveSpeed = defaultSpeed;
            }

            if (keys.inputs[0] && keys.inputs[1])
            {
                
                velocity.X = 0;
            }
            else if (keys.inputs[0] && !keys.inputs[1])
            {
                
                
                velocity.X = moveSpeed;
            }
            else if (keys.inputs[1] && !keys.inputs[0])
            {
                
                
                velocity.X = -moveSpeed;
            }
            else
            {
                
                velocity.X = 0;
            }

            if (collisionState.Below && keys.inputs[2])
            {
                velocity.Y = -Mathf.Sqrt(2 * jumpHeight * gravity);
            }

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
