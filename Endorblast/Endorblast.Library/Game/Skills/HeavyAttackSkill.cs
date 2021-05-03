using Nez;
using Endorblast.Library.Entities;

namespace Endorblast.Library.Skills
{
    public class HeavyAttackSkill : Skill
    {
        float duration;
        int damage;


        public HeavyAttackSkill(BasePlayer p) : base(p)
        {
            duration = 2f;
            damage = Nez.Random.RNG.Next(10, 100);
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
