using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Library.Enums;

namespace Endorblast.GamePlay.Items
{

    


    public class SkillItem : Item
    {
        public ActionType Type;

        public SkillItem(ActionType type)
        {
            itemType = ItemType.Skill;
            Type = type;
            switch (Type)
            {
                // case SkillType.Dash:
                //     break;
            }
        }

    }
}
