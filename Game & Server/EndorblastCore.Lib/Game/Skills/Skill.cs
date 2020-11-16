
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib.Skills;
using System.Runtime;
using EndorblastCore.Lib.Enums;
using Nez;
using EndorblastCore.Lib.Game.Utils;

namespace EndorblastCore.Lib.Skills
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
            Skill skill = Activator.CreateInstance(Type.GetType("EndorblastCore.Lib.Skills." + type.ToString() + "Skill"), caster) as Skill;

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

            if (NetworkManager.Instance != null)
            {
                isLocal = NetworkManager.Instance.WorldID == playerCaster.WorldID ? true : false;
            }
            else
            {
                isLocal = false;
            }

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
            ExitState();
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
