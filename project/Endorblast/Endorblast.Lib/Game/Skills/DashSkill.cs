using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Entities;

namespace Endorblast.Lib.Skills
{
    public class DashSkill : Skill
    {

        float duration;
        float force;
        float forceMulti = 25;

        BasePlayer movement;


        public DashSkill(BasePlayer p) : base(p)
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
            movement.MoveCharacter(new Vector2(force, 0));
            force = Mathf.Lerp(0, force, duration);
            

            if (duration <= 0)
                ExitState();
        }


    }
}
