using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;

namespace GamerEngineNet_Client
{
    class KeyboardInput : Component, IUpdatable
    {

        public bool[] _inputs;
        

        public override void Initialize()
        {
            _inputs = new bool[]
            {
                Keyboard.GetState().IsKeyDown(Keys.D),
                Keyboard.GetState().IsKeyDown(Keys.A)
            };
        }

        public void Update()
        {
            

            _inputs = new bool[]
            {
                Keyboard.GetState().IsKeyDown(Keys.D),
                Keyboard.GetState().IsKeyDown(Keys.A)
            };

            if (_inputs[0])
            {
                this.GetComponent<SpriteRenderer>().FlipX = false;
            }

            if (_inputs[1])
            {
                this.GetComponent<SpriteRenderer>().FlipX = true;
                
            }

            if (!_inputs[0] && !_inputs[1])
            {
                
            }


            SendInputToServer(_inputs);
        }

        private void SendInputToServer(bool[] inputs)
        {
            NetworkSend.SendPlayerInputs(inputs);
        }

    }
}
