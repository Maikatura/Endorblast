using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Nez;
using Microsoft.Xna.Framework;
using Nez.Tiled;
using System.Security.Cryptography.X509Certificates;

namespace MasterServer
{
    class Player : Component, IUpdatable
    {

        public int connectionID;
        public bool inGame = false;

        public float moveSpeed = 100;
        public float gravity = 1000;
        public float jumpHeight = 16 * 7;

        TiledMapMover mover;
        TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        BoxCollider boxCollider;

        Vector2 velocity;

        bool isWalking = false;
        bool isIdle = true;

        Vector2 position;
        bool[] inputs;

        SubpixelVector2 subpixelV2 = new SubpixelVector2();

        public override void OnAddedToEntity()
        {
            mover = this.GetComponent<TiledMapMover>();
            boxCollider = this.GetComponent<BoxCollider>();

            this.Transform.SetPosition(MasterScene.spawnPoint.X, MasterScene.spawnPoint.Y);

            //velocity = new Vector2(0, 0);
        }


        public void SetInput(bool[] _inputs)
        {
            inputs = _inputs;
        }

        public void Update2()
        {
            
            NetworkSend.SendPlayerPos(connectionID, this.Transform.Position, isWalking, isIdle);





        }

        public void Update()
        {
            if (inputs != null)
            {
                if (inputs[0])
                {
                    isIdle = false;
                    isWalking = true;
                    velocity.X = moveSpeed;
                }
                else if (inputs[1])
                {
                    isIdle = false;
                    isWalking = false;
                    velocity.X = -moveSpeed;
                }
                else
                {
                    isIdle = true;
                    velocity.X = 0;
                }

                //this.Transform.Position = position;

                velocity.Y += gravity * Time.DeltaTime;

                subpixelV2.Update(ref velocity);
                mover.Move(velocity * Time.DeltaTime, boxCollider, collisionState);


                if (collisionState.Right || collisionState.Left)
                {
                    velocity.X = 0;
                }

                if (collisionState.Below || collisionState.Above)
                {
                    velocity.Y = 0;
                }

                //Console.WriteLine(this.Transform.Position.X);
            }
        }

    }
}
