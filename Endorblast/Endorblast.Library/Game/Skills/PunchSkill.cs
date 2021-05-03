using Nez;
using Endorblast.Library.Entities;

namespace Endorblast.Library.Skills
{
    public class PunchSkill : Skill
    {
        
        
        float duration = .5f;
        int damage;


        public PunchSkill(BasePlayer p) : base(p)
        {
            duration = .5f;
            damage = Nez.Random.RNG.Next(1, 5);
            player = p;
        }

        public override void Update()
        {
            
            if (!inited)
            {
                inited = true;
                DoColliderCheck(player, damage);
            }

            duration -= Time.DeltaTime;

            if (duration <= 0 && inited)
            {
                ExitState();
            }
        }
    }
}