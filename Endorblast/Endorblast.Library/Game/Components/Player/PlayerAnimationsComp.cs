using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nez;
using System.Threading.Tasks;
using Nez.Sprites;
using Endorblast.Library;
using Nez.Textures;
using Endorblast;
using Endorblast.Library.Entities;
using Endorblast.Library.Game.Player.Races;

namespace Endorblast.Library
{
    public class PlayerAnimationsComp : Component
    {

        

        public SpriteAnimator hatRenderer;
        public SpriteAnimator clothRenderer;
        public SpriteAnimator shoeRenderer;

        public SpriteAnimator bodyRenderer;

        public SpriteAnimator frontHair;
        public SpriteAnimator backHair;

        public int hairID;
        


        public override void OnAddedToEntity()
        {
            CheckIfNotNull();
        }

        public void Load()
        {
            bodyRenderer = this.AddComponent(new SpriteAnimator());
            hatRenderer = this.AddComponent(new SpriteAnimator());
            clothRenderer = this.AddComponent(new SpriteAnimator());
            shoeRenderer = this.AddComponent(new SpriteAnimator());
            frontHair = this.AddComponent(new SpriteAnimator());
            backHair = this.AddComponent(new SpriteAnimator());

            // What decides what race sprites.
            

            

            int layer = (int)RenderLayers.Layer.OtherPlayerMin;
            

            backHair.SetRenderLayer(layer);
            bodyRenderer.SetRenderLayer(layer);
            shoeRenderer.SetRenderLayer(layer);
            clothRenderer.SetRenderLayer(layer);
            frontHair.SetRenderLayer(layer);
            hatRenderer.SetRenderLayer(layer);

            backHair.SetLayerDepth(0.5f);
            bodyRenderer.SetLayerDepth(0.4f);
            shoeRenderer.SetLayerDepth(0.3f);
            clothRenderer.SetLayerDepth(0.2f);
            frontHair.SetLayerDepth(0.1f);
            hatRenderer.SetLayerDepth(0);

        }

        public void SetHat(int id)
        {

        }

        public void SetCloth(int id)
        {

        }

        public void SetShoe(int id)
        {

        }

        public void LoadHair(int id)
        {
            CheckIfNotNull();

            hairID = id;

            frontHair.ReplaceAnimation("Idle", HairID.hairID[id].frontHairIdle);
            backHair.ReplaceAnimation("Idle", HairID.hairID[id].backHairIdle);

            frontHair.ReplaceAnimation("Walking", HairID.hairID[id].frontHairRunning);
            backHair.ReplaceAnimation("Walking", HairID.hairID[id].backHairRunning);
        }

        public void LoadSet(int id)
        {
            CheckIfNotNull();

            hatRenderer.ReplaceAnimation("Idle", ClothID.clothes[id].hatIdle);
            clothRenderer.ReplaceAnimation("Idle", ClothID.clothes[id].clothIdle);
            shoeRenderer.ReplaceAnimation("Idle", ClothID.clothes[id].shoeIdle);

            hatRenderer.ReplaceAnimation("Walking", ClothID.clothes[id].hatRunning);
            clothRenderer.ReplaceAnimation("Walking", ClothID.clothes[id].clothRunning);
            shoeRenderer.ReplaceAnimation("Walking", ClothID.clothes[id].shoeRunning);



            if (Entity.Name == "DummyCharaSelect" || Entity.Name == "DummyCharaCreate")
            {
                CheckAnimations("");
            }
        }

        public void CheckAnimations(string state)
        {
            CheckIfNotNull();

            if (state == "")
                return;
            
            if (bodyRenderer.Animations.ContainsKey(state))
                bodyRenderer.Play(state);
            
            // if (hatRenderer.Animations.ContainsKey(state))
            //     hatRenderer.Play(state);
            //
            // if (clothRenderer.Animations.ContainsKey(state))
            //     clothRenderer.Play(state);
            //
            // if (shoeRenderer.Animations.ContainsKey(state))
            //     shoeRenderer.Play(state);
        }

        private void CheckIfNotNull()
        {
            if (shoeRenderer == null && clothRenderer == null && hatRenderer == null && bodyRenderer == null &&
                frontHair == null && backHair == null)
            {
                Load();
            }
        }

        public void AnimationHandler(string state, FacingDirection facingDirection)
        {
            if (this.GetComponent<PlayerAnimationsComp>() != null)
            {
                if (facingDirection == FacingDirection.Left)
                {
                    ChangeAllRenderers(facingDirection);
                    
                    this.GetComponent<PlayerAnimationsComp>().CheckAnimations(state);
                }
            }
        }

        void ChangeAllRenderers(FacingDirection facing)
        {
            SpriteAnimator[] renderers = this.GetComponents<SpriteAnimator>().ToArray();

            for (int i = 0; i < renderers.Length; i++)
            {
                if (facing == FacingDirection.Left)
                {
                    renderers[i].FlipX = true;
                }
                else
                {
                    renderers[i].FlipX = false;
                }
            }
        }
    }
}
