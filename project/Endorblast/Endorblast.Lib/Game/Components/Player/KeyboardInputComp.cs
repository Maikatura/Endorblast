using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Endorblast.Lib.Game.Network;
using Lidgren.Network;

namespace Endorblast.Lib
{
    public class KeyboardInputComp : Component, IUpdatable
    {


        Keys dKey = Keys.D;
        Keys aKey = Keys.A;
        Keys space = Keys.Space;

        public bool[] inputs;
        public bool MoveLeft = false;
        public bool MoveRight = false;
        public bool isSprinting = false;
        public bool isClient = true;
        public bool isServer = true;
        public bool isJumping = false;



        Vector2 OldPosition;

        public bool OldPosIsPos =>
            Transform.Position.X == OldPosition.X &&
            Transform.Position.Y == OldPosition.Y;

        public KeyboardInputComp(bool isClient = true, bool isServer = false)
        {
            this.isClient = isClient;
            this.isServer = isServer;
            isSprinting = false;
            Initialize();
        }

        public override void Initialize()
        {
            inputs = new bool[]
            {
                Keyboard.GetState().IsKeyDown(dKey),
                Keyboard.GetState().IsKeyDown(aKey),
                Keyboard.GetState().IsKeyDown(space),
            };
        }

        public void Update()
        {



            if (isClient)
            {


                if (Keyboard.GetState().IsKeyDown(dKey))
                {
                    MoveRight = true;
                }
                else
                {
                    MoveRight = false;
                }

                if (Keyboard.GetState().IsKeyDown(aKey))
                {
                    MoveLeft = true;
                }
                else
                {
                    MoveLeft = false;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    isSprinting = true;
                }
                else
                {
                    isSprinting = false;
                }

                if (Keyboard.GetState().IsKeyDown(space))
                {
                    isJumping = true;
                }
                else
                {
                    isJumping = false;
                }

                
                

                
                OldPosition = Transform.Position;
            }


        }

        

        public void SetInputs(KeyboardInputComp inputsComp)
        {
            if (!isClient || isServer)
            {
                this.MoveLeft = inputsComp.MoveLeft;
                this.MoveRight = inputsComp.MoveRight;
                this.isSprinting = inputsComp.isSprinting;
                this.isJumping = inputsComp.isJumping;
            }
            
            
        }

    }
}

