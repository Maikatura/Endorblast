using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Library;
using Endorblast.Library.Entities;
using Endorblast.Library.Entities.Player;

namespace Endorblast.Library.Skills
{
    class BasicSkill : Skill
    {



        float duration = 0.7f;
        PlayerAnimationsComp anims;
        PlayerMovementComp move;
        bool hasTrig = false;

        int damage;

        public BasicSkill(BasePlayerEntity p) : base(p)
        {
            anims = p.GetComponent<PlayerAnimationsComp>();
            move = p.GetComponent<PlayerMovementComp>();
            anims.CheckAnimations("Attack");
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
                anims.CheckAnimations("Attack");
                ExitState();
            }

        }
    }
}
