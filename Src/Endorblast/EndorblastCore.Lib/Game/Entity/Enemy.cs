using EndorblastCore.Lib.Enums;
using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Lib
{
    public class Enemy : Component, IUpdatable
    {


        TextComponent healthIndicatior;

        public int attackDamage { get; set; }
        public int enemyHealth { get; set; }


        public int maxHealth;

        public EnemyType type;

        public override void OnAddedToEntity()
        {
            healthIndicatior = this.AddComponent(new TextComponent());
            healthIndicatior.SetHorizontalAlign(HorizontalAlign.Center);
            healthIndicatior.SetVerticalAlign(VerticalAlign.Center);
            healthIndicatior.SetLocalOffset(new Vector2(0, -35));
            healthIndicatior.Text = $"{enemyHealth}/{maxHealth}";
            healthIndicatior.SetColor(Color.Crimson);
            healthIndicatior.RenderLayer = RenderLayers.FrontObjectLayer;
        }


        public Enemy()
        {
            
            enemyHealth = 1000;
            maxHealth = enemyHealth;
            attackDamage = 1;
        }




        public void TakeDamage(int damage)
        {
            enemyHealth -= damage;

            healthIndicatior.Text = $"{enemyHealth}/{maxHealth}";
        }

        public void Update()
        {
            if (enemyHealth <= 0)
            {
                this.Entity.Destroy();
            }
        }


        public StaticEnemy ToStaticEnemy()
        {
            var lc = new StaticEnemy();



            lc.Type = this.type;
            lc.PosX = this.Transform.Position.X;
            lc.PosY = this.Transform.Position.Y;

            return lc;
        }
    }
}
