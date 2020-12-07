using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Lib.Game.Utils
{
    public class AttackLabel : Component, IUpdatable
    {
        TextComponent label;
        Entity thisEntity;
        

        float travelMaxDistance = 50;
        float travelDistance = 0;
        float startOffset = 35;

        public AttackLabel(Entity entity, int damage)
        {
            thisEntity = entity;
            label = thisEntity.AddComponent(new TextComponent());
            label.Text = damage.ToString();
            label.SetScale(2, 2);
            label.SetHorizontalAlign(HorizontalAlign.Center);
            label.SetVerticalAlign(VerticalAlign.Center);
            label.SetRenderLayer(RenderLayers.FrontObjectLayer);
        }


        public void Update()
        {

            if (travelDistance <= travelMaxDistance)
            {

                if (label.GetScaleX() <= 0 || label.GetScaleY() <= 0)
                {
                    DestroyThis();
                }
                label.SetLocalOffset(new Vector2(0, -startOffset - travelDistance));
                travelDistance += 1.5f;
                label.SetScale(label.GetScale() - new Vector2(0.05f, 0.05f));
                label.Color = Color.Yellow;
            }
            else
            {
                DestroyThis();
            }

        }

        public void DestroyThis()
        {
            Console.WriteLine("Test");
            this.RemoveComponent(label);
            this.RemoveComponent(this);
        }
    }
}
