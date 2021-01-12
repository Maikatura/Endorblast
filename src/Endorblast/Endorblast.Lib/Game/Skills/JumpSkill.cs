using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Game;
using Endorblast.Lib.Entities;

namespace Endorblast.Lib.Skills
{
    class JumpSkill : Skill
    {

        public JumpSkill(BasePlayer p) : base(p)
        {
            player = p;

            if (player.collisionState.Below)
            {
                player.velocity.Y = -Mathf.Sqrt(2 * PlayerSettings.jumpHeight * PlayerSettings.gravity);
            }
            
            ExitState();
        }

    }
    
}
