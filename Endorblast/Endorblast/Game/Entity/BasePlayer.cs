using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Game.Skills;

namespace Endorblast
{
    public class BasePlayer : Component, IUpdatable
    {

        public int Speed = 150;
        public Vector2 Position;
        public Vector2 OldPosition;
        public int WorldID;
        public string CharacterName;

        public Vector2 latestDirection;
        public Vector2 direction;


        public Skill currentSkill;
        public bool skillButtonUp = true;

        public virtual void Update()
        {
            currentSkill?.Update();
            
        }

        public void DoSkill(SkillType type, BasePlayer player, float rotation)
        {
            if (currentSkill != null)
            {
                if (currentSkill.isExiting)
                {
                    currentSkill = null;
                }
            }
            else
            {
                if (currentSkill == null)
                {
                    currentSkill = Skill.DoSkill(type, player, rotation);
                }
            }
        }
    }
}
