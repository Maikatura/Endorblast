using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib.Enums;

namespace Endorblast.GamePlay.Items
{

    


    public class SkillItem : Item
    {
        public SkillType Type;

        public SkillItem(SkillType type)
        {
            itemType = ItemType.Skill;
            Type = type;
            switch (Type)
            {
                case SkillType.Dash:
                    break;
            }
        }

    }
}
