using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Lib.Skills
{
    class JumpSkill : Skill
    {
        float duration = 0.7f;
        PlayerAnimations anims;
        PlayerMovement move;
        bool hasTrig = false;
        BasePlayer player;

        public JumpSkill(BasePlayer p) : base(p)
        {
            anims = p.GetComponent<PlayerAnimations>();
            move = p.GetComponent<PlayerMovement>();

            player = p;


            if (player.collisionState.Below)
            {
                player.velocity.Y = -Mathf.Sqrt(2 * player.jumpHeight * player.gravity);
            }
            
            ExitState();
        }

    }
    
}
