using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib;

namespace EndorblastCore.Lib.Skills
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
            player = p;
            
        }

        public override void Update()
        {
            duration -= Time.DeltaTime;

            if (!hasTrig)
            {
                hasTrig = true;
                DoColliderCheck(player);
            }

            if (duration <= 0 && anims.bodyRenderer.AnimationState == Nez.Sprites.SpriteAnimator.State.Completed)
            {
                anims.CheckAnimations(PlayerState.Idle);

                ExitState();
            }

        }
    }
}
