using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer
{
    public class Inputs : Component
    {
        public bool[] _inputs;

        public bool MoveLeft;
        public bool MoveRight;
        public bool isSprinting;


        public void SetInputs(bool[] inputs, bool isSprinting)
        {
            _inputs = inputs;
            this.isSprinting = isSprinting;
        }

    }
}
