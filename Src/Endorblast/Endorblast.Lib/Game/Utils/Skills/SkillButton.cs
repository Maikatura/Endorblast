using Endorblast.Lib.Enums;
using Endorblast.Lib.Skills;
using Nez;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Endorblast.Lib.Entities;

namespace Endorblast.Lib.Utils.Skills
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
