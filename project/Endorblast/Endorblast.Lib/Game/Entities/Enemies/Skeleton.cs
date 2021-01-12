using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Entities;

namespace Endorblast.Lib.Enemies
{
    public class Skeleton : Enemy
    {

        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();


            var coll = this.Entity.AddComponent(new BoxCollider(64, 64));
            coll.IsTrigger = true;
            var sprite = this.Entity.AddComponent(new SpriteRenderer(ContentLoader.LoadSprite("/Sprites/Enemies/Testing/Enemy1.png")));
            sprite.RenderLayer = RenderLayers.ObjectLayer;

            var test1 = this.Entity.AddComponent(new SpriteAnimator());
            test1.AddAnimation("Fire", ContentLoader.LoadSprites("/Sprites/GameObjects/Fire/Fire1.png", 96, 96), 30);
            test1.LocalOffset = new Microsoft.Xna.Framework.Vector2(0, -16);
            test1.Play("Fire");
            test1.RenderLayer = RenderLayers.ObjectLayer;
        }

        public Skeleton()
        {
            type = EnemyType.Skeleton;
            enemyHealth = 1000;
            maxHealth = enemyHealth;
            attackDamage = 1;
        }

        public void SetPosition(float x, float y)
        {
            this.Transform.Position = new Vector2(x, y);
        }

    }
}
