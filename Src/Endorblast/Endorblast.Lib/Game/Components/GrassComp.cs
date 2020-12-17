using System;
using Endorblast.Lib.Entities;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Textures;


namespace Endorblast.Lib.Components
{
    public class GrassComp : Component, IUpdatable, ITriggerListener
    {
        private BoxCollider boxCollider;
        private SpriteRenderer spriteRenderer;


        private bool isBending = false;
        private bool isRebounding = false;

        private int boxWidth, boxHeight;
        private Sprite sprite;

        private Collider cache;

        private float distance = 0f;
        
        private float bend_velocity = 3.5f;

        private float exitOffset;
        private float enterOffset;

        ColliderTriggerHelper _triggerHelper;


        private float posTesting;

        public GrassComp(int boxWidth, int boxHeight, Sprite sprite)
        {
            this.boxWidth = boxWidth;
            this.boxHeight = boxHeight;
            this.sprite = sprite;
        }

        public override void Initialize()
        {
            base.Initialize();
            boxCollider =
                this.Entity.AddComponent(new BoxCollider(sprite.Texture2D.Width, sprite.Texture2D.Height * 2));
            boxCollider.IsTrigger = true;
            spriteRenderer = this.Entity.AddComponent(new SpriteRenderer(sprite));
            spriteRenderer.SetOrigin(new Vector2(sprite.Texture2D.Width / 2, sprite.Texture2D.Height));
            spriteRenderer.SetRenderLayer(RenderLayers.ObjectLayer);
            
            _triggerHelper = new ColliderTriggerHelper(Entity);
        }


        public void Update()
        {
            if (isRebounding)
            {
                var lerp = Mathf.LerpAngle(exitOffset, 0, Time.DeltaTime * 3);
                exitOffset = SetVertHorizontalOffset(lerp);
            }

            _triggerHelper.Update();
        }

        

        float SetVertHorizontalOffset(float offset)
        {
            float setOffset = offset;
            Entity.SetRotation(setOffset);
            
            return setOffset;
        }

        public void OnTriggerEnter(Collider other, Collider local)
        {
            if (other.HasComponent<BasePlayer>() || local.HasComponent<BasePlayer>())
            {
                enterOffset = other.Transform.Position.X - local.Transform.Position.X;
            }
        }

        public void OnTriggerStay(Collider other, Collider local)
        {
            if (other.HasComponent<BasePlayer>() || local.HasComponent<BasePlayer>())
            {
            
                var offset = other.Transform.Position.X - local.Transform.Position.X;
            
                if (isBending || Math.Sign(enterOffset) != Math.Sign(offset))
                {
                    isRebounding = false;
                    isBending = true;
                    
                    var radius = boxCollider.Width / 2 + boxCollider.Bounds.Size.X * 0.5f;
                    exitOffset = Mathf.Map(offset, -radius, radius, -1f, 1f);
                    SetVertHorizontalOffset(exitOffset);
                }
            }
        }

        public void OnTriggerExit(Collider other, Collider local)
        {
            if (other.HasComponent<BasePlayer>() || local.HasComponent<BasePlayer>())
            {
                if (isBending)
                {
                    // apply a force in the opposite direction that we are currently bending
                    
                }
            
                isBending = false;
                isRebounding = true;
            }
        }
    }
}