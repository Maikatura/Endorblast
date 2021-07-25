using System;
using System.Numerics;
using Endorblast.Library.Entities;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Textures;
using Nez.Tweens;
using Vector2 = Microsoft.Xna.Framework.Vector2;


namespace Endorblast.Library.Components
{
    public class GrassComp : Component, IUpdatable, ITriggerListener
    {
        private BoxCollider boxCollider;
        private PolygonMesh polyMesh;
        ColliderTriggerHelper _triggerHelper;

        private TransformSpringTween spring;

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

        private float lerpValue = 0f;
        private float lerpValueCache = 0f;
        private float lerpTime = 1f;

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
            var halfHeight = sprite.Texture2D.Height / 2;
            
            // Offset of vertex so it look good (Top is most offset Middle is half of the top offset)
            var leftMiddle = -halfWidth;
            var leftTop= -halfWidth;
            var rightTop = halfWidth;
            var rightMiddle= halfWidth;
            
            // Points to set on grass so its sways back and forward (Its doesn't rotate)
            var points = new Vector2[6];
            points[0] = new Vector2(-halfWidth, 0);
            points[1] = new Vector2(leftMiddle, -halfHeight);
            points[2] = new Vector2(leftTop, -height);
            points[3] = new Vector2(rightTop, -height);
            points[4] = new Vector2(rightMiddle, -halfHeight);
            points[5] = new Vector2(halfWidth, 0);
            
            polyMesh = new PolygonMesh(points);
            polyMesh.SetTexture(sprite.Texture2D);
            polyMesh.SetRenderLayer((int)RenderLayers.Layer.ObjectLayer);

            this.Entity.AddComponent(polyMesh);
            
        }


        public void Update()
        {
            

            
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
            
        }

        public void OnTriggerStay(Collider other, Collider local)
        {
            
        }

        public void OnTriggerExit(Collider other, Collider local)
        {
            
        }
    }
}