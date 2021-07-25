using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Library.Entities;
using Endorblast.Library.Entities.Player;
using Endorblast.Library.Game;

namespace Endorblast.Library.Skills
{
    class JumpSkill : Skill
    {

        public JumpSkill(BasePlayerEntity p) : base(p)
        {
            player = p;

            // if (player.collisionState.Below)
            // {
            //     player.velocity.Y = -Mathf.Sqrt(2 * PlayerSettings.jumpHeight * PlayerSettings.gravity);
            // }
            
            ExitState();
        }

    }
    
}
