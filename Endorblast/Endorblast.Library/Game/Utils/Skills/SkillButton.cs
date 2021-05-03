using Endorblast.Library.Skills;
using Nez;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Endorblast.Library.Entities;
using Endorblast.Library.Enums;

namespace Endorblast.Library.Utils.Skills
{
    public class SkillButton
    {


        Image icon;
        public ActionType Action;

        public void CallSkill(BasePlayer caster, float rotation)
        {
            if (!caster.HasComponent<MainPlayer>())
                return;


            caster.DoSkill(Action, caster, rotation);
        }


    }
}
