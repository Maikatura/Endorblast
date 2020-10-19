using Endorblast.GamePlay.Items;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Game.Skills;
using System.Runtime;


namespace Endorblast.Game.Skills
{

    

    public class Skill
    {
        public BasePlayer player;
        public bool isExiting;
        public bool isLocal;
        public bool inited = false;
        

        public SkillType skillType;

        public static Skill DoSkill(SkillType type, BasePlayer caster, float dir)
        {
            //Console.WriteLine(Type.GetType(typeof(DashSkill).Name));
            Skill skill = Activator.CreateInstance(Type.GetType("Endorblast.Game.Skills." + type.ToString() + "Skill"), caster) as Skill;

            if (skill == null)
            {
                Console.WriteLine($"DoSkill - {type.ToString()} WAS NULL");
                return null;
            }

            return skill;
        }

        public Skill() { }

        public Skill(BasePlayer playerCaster)
        {
            player = playerCaster;

            string skillName = GetType().Name;
            skillName = skillName.Remove(skillName.Length - 5, 5);
            skillType = (SkillType)Enum.Parse(typeof(SkillType), skillName);

            isLocal = NetworkManager.WorldID == player.WorldID ? true : false;

            // Set Sprite Effect!
            //SpriteEffects = playerCaster.SpriteEffects;
            //Size = caster.size;
            
        }


        public virtual void ExitState()
        {
            
            isExiting = true;
        }

        public virtual void Update()
        {
           
        }
    }
}
