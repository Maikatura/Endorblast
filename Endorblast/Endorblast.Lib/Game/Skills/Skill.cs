
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Skills;
using System.Runtime;
using Endorblast.Lib.Enums;
using Nez;
using Endorblast.Lib.Game.Utils;

namespace Endorblast.Lib.Skills
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
            Skill skill = Activator.CreateInstance(Type.GetType("Endorblast.Lib.Skills." + type.ToString() + "Skill"), caster) as Skill;

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

            //isLocal = NetworkManager.WorldID == playerCaster.WorldID ? true : false;

            // Set Sprite Effect!
            //SpriteEffects = playerCaster.SpriteEffects;
            //Size = caster.size;

        }

        public static Skill DoSkill(SkillType type, BasePlayer playerCaster, float dir, float offset)
        {
            var skill = DoSkill(type, playerCaster, dir);

            return skill;
        }


        public virtual void ExitState()
        {
            isExiting = true;
        }

        public virtual void Update()
        {

        }

        public void DoColliderCheck(BasePlayer player)
        {
            // fetch anything that we might overlap with at our position excluding ourself. We don't care about ourself here.
            var neighborColliders = Physics.BoxcastBroadphaseExcludingSelf(player.GetComponent<Collider>());

            // loop through and check each Collider for an overlap
            foreach (var collider in neighborColliders)
            {
                if (player.GetComponent<Collider>().Overlaps(collider) && collider.HasComponent<Enemy>())
                {
                    collider.AddComponent(new AttackLabel(Core.Scene, collider.Entity, 10));
                    collider.GetComponent<Enemy>().TakeDamage(10);
                    Console.WriteLine("Entity: {0}", collider.Entity.Name);
                }
                    

            }
        }
    }
}
