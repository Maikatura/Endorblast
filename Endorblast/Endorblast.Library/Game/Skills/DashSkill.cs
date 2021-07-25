using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Library.Entities;
using Endorblast.Library.Entities.Player;

namespace Endorblast.Library.Skills
{
    public class DashSkill : Skill
    {

        float duration;
        float force;
        float forceMulti = 25;

        BasePlayerEntity movement;


        public DashSkill(BasePlayerEntity p) : base(p)
        {
            // Animation (If you want animation)
            movement = p;


            // Force
            force = 30 * forceMulti;
            duration = 1;
        }



        public override void Update()
        {
            duration -= Time.DeltaTime;
            //movement.MoveCharacter(new Vector2(force, 0));
            force = Mathf.Lerp(0, force, duration);
            

            if (duration <= 0)
                ExitState();
        }


    }
}
