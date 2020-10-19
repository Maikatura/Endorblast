using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace Endorblast
{
    public class KeyboardInput : Component, IUpdatable
    {

        public bool[] _inputs;
        public Keys dKey = Keys.D;
        public Keys aKey = Keys.A;
        public Keys space = Keys.Space;

        public bool MoveLeft;
        public bool MoveRight;
        public bool isSprinting;

        public override void Initialize()
        {
            _inputs = new bool[]
            {
                Keyboard.GetState().IsKeyDown(dKey),
                Keyboard.GetState().IsKeyDown(aKey),
                Keyboard.GetState().IsKeyDown(space),
            };
        }

        public void Update()
        {


            _inputs = new bool[]
            {
                Keyboard.GetState().IsKeyDown(Keys.D),
                Keyboard.GetState().IsKeyDown(Keys.A),
                Keyboard.GetState().IsKeyDown(Keys.Space),
            };

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

        }

        private void SendInputToServer(bool[] inputs)
        {
            //NetworkSend.SendPlayerInputs(inputs);
        }

    }
}
