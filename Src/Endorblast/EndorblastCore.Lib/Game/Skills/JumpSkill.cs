using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Lib.Skills
{
    class JumpSkill : Skill
    {

        public JumpSkill(BasePlayer p) : base(p)
        {
            player = p;

            if (player.collisionState.Below)
            {
                player.velocity.Y = -Mathf.Sqrt(2 * player.jumpHeight * player.gravity);
            }
            
            ExitState();
        }

    }
    
}
