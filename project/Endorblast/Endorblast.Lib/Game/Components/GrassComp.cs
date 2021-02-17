using System;
using Endorblast.Lib.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.PhysicsShapes;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tweens;



namespace Endorblast.Lib.Components
{
    public class GrassComp : Component, IUpdatable, ITriggerListener
    {
        private BoxCollider boxCollider;
        private PolygonMesh polyMesh;
        ColliderTriggerHelper _triggerHelper;

        private bool isBending = false;
        private bool isRebounding = false;
        private bool isWindEnabled = true;

        private int boxWidth, boxHeight;
        private Sprite sprite;

        private Collider cache;

        private float distance = 0f;
        private float bend_velocity = 3.5f;
        private float bendFactor = 20f;
        private float exitOffset;
        private float enterOffset;
        private float posTesting;

        public GrassComp(int boxWidth, int boxHeight, Sprite sprite)
        {
            this.boxWidth = boxWidth;
            this.boxHeight = boxHeight;
            this.sprite = sprite;
        }

        public override void Initialize()
        {
            //BoxHelper.ReturnAmount(16, 16, 1);
            
            base.Initialize();
            boxCollider =
                this.Entity.AddComponent(new BoxCollider(sprite.Texture2D.Width, sprite.Texture2D.Height * 2));
            boxCollider.IsTrigger = true;

            _triggerHelper = new ColliderTriggerHelper(Entity);
            
            var width = sprite.Texture2D.Width;
            var height = sprite.Texture2D.Height;
            
            
            var halfWidth = sprite.Texture2D.Width / 2;
            var halfheight = sprite.Texture2D.Height / 2;
            
            // Offset of vertex so it look good (Top is most offset Middle is half of the top offset)
            var leftMiddle = -halfWidth;
            var leftTop= -halfWidth;
            var rightTop = halfWidth;
            var rightMiddle= halfWidth;
            
            // Points to set on grass so its sways back and forward (Its doesn't rotate)
            var points = new Vector2[6];
            points[0] = new Vector2(-halfWidth, 0);
            points[1] = new Vector2(leftMiddle, -halfheight);
            points[2] = new Vector2(leftTop, -height);
            points[3] = new Vector2(rightTop, -height);
            points[4] = new Vector2(rightMiddle, -halfheight);
            points[5] = new Vector2(halfWidth, 0);
            
            polyMesh = new PolygonMesh(points);
            polyMesh.SetTexture(sprite.Texture2D);
            polyMesh.SetRenderLayer(RenderLayers.ObjectLayer);

            this.Entity.AddComponent(polyMesh);
        }


        public void Update()
        {
            if (isWindEnabled)
            {
                var windForce = 1f + Mathf.Pow(Mathf.Sin(Time.DeltaTime * 3f + 0.3f) * 0.7f + 0.05f, 4 ) * 0.05f * 10f;
            }
            
            if (isRebounding)
            {
                var lerp = Mathf.LerpAngle(exitOffset, 0, Time.DeltaTime);
                exitOffset = SetVertHorizontalOffset(lerp);
            }

            _triggerHelper.Update();
        }

        private float SetVertHorizontalOffset(float offset)
        {
            // Variables for size and offset calculation.
            float halfOffset = offset / 2;
            var width = sprite.Texture2D.Width;
            var height = sprite.Texture2D.Height;
            var halfWidth = sprite.Texture2D.Width / 2;
            var halfheight = sprite.Texture2D.Height / 2;
            
            // Offset of vertex so it look good (Top is most offset Middle is half of the top offset)
            var leftMiddle= -width / 2 + halfOffset * (bendFactor/ 2) / Transform.LocalScale.X;
            var leftTop= -width / 2 + offset * bendFactor / Transform.LocalScale.X;
            var rightTop = width / 2 + offset * bendFactor / Transform.LocalScale.X;
            var rightMiddle= width / 2 + halfOffset * (bendFactor / 2) / Transform.LocalScale.X;
            
            // Points to set on grass so its sways back and forward (Its doesn't rotate)
            var points = new Vector2[6];
            points[0] = new Vector2(-halfWidth, 0);
            points[1] = new Vector2(leftMiddle, -halfheight);
            points[2] = new Vector2(leftTop, -height);
            points[3] = new Vector2(rightTop, -height);
            points[4] = new Vector2(rightMiddle, -halfheight);
            points[5] = new Vector2(halfWidth, 0);

            polyMesh.SetVertPositions(points);
            
            return offset;
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