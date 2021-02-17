using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nez;
using System.Threading.Tasks;
using Nez.Sprites;
using Endorblast.Lib;
using Nez.Textures;
using Endorblast;
using Endorblast.Lib.Entities;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Game.Player.Races;

namespace Endorblast.Lib
{
    public class PlayerAnimationsComp : Component
    {

        private RaceClass sprites;

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
            sprites = new HumanFemale();
            
            SpriteAnimation walkAnim = new SpriteAnimation(sprites.walking, 10);
            SpriteAnimation idleAnim = new SpriteAnimation(sprites.idle, 10);
            SpriteAnimation basicAttackAnim = new SpriteAnimation(sprites.basicAttack, 10);
            SpriteAnimation slideAnim = new SpriteAnimation(sprites.slide, 10);

            bodyRenderer.AddAnimation("Idle", idleAnim);
            bodyRenderer.AddAnimation("Walking", walkAnim);
            bodyRenderer.AddAnimation("BasicAttack", basicAttackAnim);
            bodyRenderer.AddAnimation("Slide", slideAnim);

            int layer = RenderLayers.OtherPlayersLayer;
            if (this.HasComponent<MainPlayer>())
                layer = RenderLayers.MainPlayerLayer;

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
                CheckAnimations(PlayerState.IdlePause);
            }
        }

        public void CheckAnimations(PlayerState state)
        {
            CheckIfNotNull();


            switch (state)
            {
                case PlayerState.Idle:

                    bodyRenderer.Play("Idle");
                    hatRenderer.Play("Idle");
                    clothRenderer.Play("Idle");
                    shoeRenderer.Play("Idle");
                    frontHair.Play("Idle");
                    backHair.Play("Idle");
                    break;

                case PlayerState.Running:
                    bodyRenderer.Play("Walking");
                    hatRenderer.Play("Walking");
                    clothRenderer.Play("Walking");
                    shoeRenderer.Play("Walking");
                    frontHair.Play("Walking");
                    backHair.Play("Walking");
                    break;

                case PlayerState.IdlePause:
                    bodyRenderer.Play("Idle");
                    hatRenderer.Play("Idle");
                    clothRenderer.Play("Idle");
                    shoeRenderer.Play("Idle");

                    bodyRenderer.Pause();
                    hatRenderer.Pause();
                    clothRenderer.Pause();
                    shoeRenderer.Pause();
                    break;

                case PlayerState.BasicAttack:
                    bodyRenderer.Play("BasicAttack", SpriteAnimator.LoopMode.Once);
                    break;
                
                case PlayerState.Slide:
                    bodyRenderer.Play("Slide", SpriteAnimator.LoopMode.Loop);
                    
                    break;

                default:
                    Console.WriteLine("### ERROR: Can't find animation type");
                    break;
            }
        }

        private void CheckIfNotNull()
        {
            if (shoeRenderer == null && clothRenderer == null && hatRenderer == null && bodyRenderer == null &&
                frontHair == null && backHair == null)
            {
                Load();
            }
        }

        public void AnimationHandler(PlayerState state, FacingDirection facingDirection)
        {
            if (this.GetComponent<PlayerAnimationsComp>() != null)
            {
                if (facingDirection == FacingDirection.Left && state == PlayerState.Running)
                {
                    ChangeAllRenderers(facingDirection);

                    if (this.GetComponent<PlayerAnimationsComp>().bodyRenderer.CurrentAnimationName != "Walking"
                        && this.GetComponent<PlayerAnimationsComp>().bodyRenderer.CurrentAnimationName != "BasicAttack")
                    {
                        this.GetComponent<PlayerAnimationsComp>().CheckAnimations(state);


                    }
                }

                if (facingDirection == FacingDirection.Right && state == PlayerState.Running)
                {
                    ChangeAllRenderers(facingDirection);

                    if (this.GetComponent<PlayerAnimationsComp>().bodyRenderer.CurrentAnimationName != "Walking"
                        && this.GetComponent<PlayerAnimationsComp>().bodyRenderer.CurrentAnimationName != "BasicAttack")
                    {
                        this.GetComponent<PlayerAnimationsComp>().CheckAnimations(state);
                    }
                }

                if (state == PlayerState.Idle)
                {
                    if (this.GetComponent<PlayerAnimationsComp>().bodyRenderer.CurrentAnimationName != "Idle"
                        && this.GetComponent<PlayerAnimationsComp>().bodyRenderer.CurrentAnimationName != "BasicAttack")
                    {
                        this.GetComponent<PlayerAnimationsComp>().CheckAnimations(state);
                    }
                }

                if (state == PlayerState.Slide)
                {
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
