using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Game.Skills
{
    class BasicSkill : Skill
    {
        float duration = 0.7f;
        PlayerAnimations anims;
        PlayerMovement move;
        bool hasTrig = false;
        
        public BasicSkill(BasePlayer p) : base(p) 
        {
            anims = p.GetComponent<PlayerAnimations>();
            move = p.GetComponent<PlayerMovement>();
            anims.CheckAnimations(PlayerState.BasicAttack);
        }

        public override void Update()
        {
            duration -= Time.DeltaTime;




            if (duration <= 0)
            {
                if (!hasTrig)
                {
                    hasTrig = true;
                    anims.CheckAnimations(PlayerState.Idle);
                }
               
                
                ExitState();
            }
                
        }
    }
}
