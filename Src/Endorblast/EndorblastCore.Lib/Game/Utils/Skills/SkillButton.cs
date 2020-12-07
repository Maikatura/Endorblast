using EndorblastCore.Lib.Enums;
using EndorblastCore.Lib.Skills;
using Nez;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndorblastCore.Lib.Utils.Skills
{
    public class SkillButton
    {


        Image icon;
        public SkillType skill;

        public void CallSkill(BasePlayer caster, float rotation)
        {
            if (!caster.HasComponent<MainPlayer>())
                return;


            caster.DoSkill(skill, caster, rotation);
        }


    }
}
