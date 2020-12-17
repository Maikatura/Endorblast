using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib;
using Endorblast.Lib.Entities;

namespace Endorblast.Lib.Skills
{
    class BasicSkill : Skill
    {



        float duration = 0.7f;
        PlayerAnimations anims;
        PlayerMovement move;
        bool hasTrig = false;

        int damage;

        public BasicSkill(BasePlayer p) : base(p)
        {
            anims = p.GetComponent<PlayerAnimations>();
            move = p.GetComponent<PlayerMovement>();
            anims.CheckAnimations(PlayerState.BasicAttack);
            player = p;
            damage = Nez.Random.RNG.Next(1, 15);
        }

        public override void Update()
        {
            if (!inited)
            {
                inited = true;
                DoColliderCheck(player, damage);
            }

            if (anims.bodyRenderer.AnimationState == Nez.Sprites.SpriteAnimator.State.Completed && inited)
            {
                anims.CheckAnimations(PlayerState.Idle);
                ExitState();
            }

        }
    }
}
