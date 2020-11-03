using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Lib.Skills
{
    public class DashSkill : Skill
    {

        float duration = 1;
        float force;
        float forceMulti = 50;

        BasePlayer movement;


        public DashSkill(BasePlayer p) : base(p)
        {
            // Animation (If you want animation)
            movement = p;
            // Force
            force = 20 * forceMulti;
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
