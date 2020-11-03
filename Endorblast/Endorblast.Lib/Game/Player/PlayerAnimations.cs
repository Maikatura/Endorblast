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

namespace Endorblast.Lib
{
    public class PlayerAnimations : Component
    {

        public SpriteAnimator hatRenderer;
        public SpriteAnimator clothRenderer;
        public SpriteAnimator shoeRenderer;

        public SpriteAnimator bodyRenderer;

        public SpriteAnimator frontHair;
        public SpriteAnimator backHair;


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

            Sprite[] walking = Sprite.SpritesFromAtlas(PlayerContent.playerWalking, 64, 64).ToArray();
            Sprite[] idle = Sprite.SpritesFromAtlas(PlayerContent.playerIdle, 64, 64).ToArray();
            Sprite[] basicAttack = Sprite.SpritesFromAtlas(PlayerContent.playerBasicAttack, 64, 64).ToArray();

            SpriteAnimation walkAnim = new SpriteAnimation(walking, 10);
            SpriteAnimation idleAnim = new SpriteAnimation(idle, 10);
            SpriteAnimation basicAttackAnim = new SpriteAnimation(basicAttack, 10);

            bodyRenderer.AddAnimation("Idle", idleAnim);
            bodyRenderer.AddAnimation("Walking", walkAnim);
            bodyRenderer.AddAnimation("BasicAttack", basicAttackAnim);


            backHair.SetRenderLayer(30);
            bodyRenderer.SetRenderLayer(29);
            shoeRenderer.SetRenderLayer(28);
            clothRenderer.SetRenderLayer(27);
            frontHair.SetRenderLayer(26);
            hatRenderer.SetRenderLayer(25);

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



            if (Entity.Name == "DummyCharaSelect")
            {
                CheckAnimations(PlayerState.IdlePause);
            }
        }

        public void CheckAnimations(PlayerState state)
        {
            CheckIfNotNull();

            if (state == PlayerState.Running)
            {
                bodyRenderer.Play("Walking");
                hatRenderer.Play("Walking");
                clothRenderer.Play("Walking");
                shoeRenderer.Play("Walking");
                frontHair.Play("Walking");
                backHair.Play("Walking");
            }

            if (state == PlayerState.Idle)
            {
                bodyRenderer.Play("Idle");
                hatRenderer.Play("Idle");
                clothRenderer.Play("Idle");
                shoeRenderer.Play("Idle");
                frontHair.Play("Idle");
                backHair.Play("Idle");
            }

            if (state == PlayerState.BasicAttack)
            {
                bodyRenderer.Play("BasicAttack", SpriteAnimator.LoopMode.Once);
            }

            if (state == PlayerState.IdlePause)
            {
                bodyRenderer.Play("Idle");
                hatRenderer.Play("Idle");
                clothRenderer.Play("Idle");
                shoeRenderer.Play("Idle");

                bodyRenderer.Pause();
                hatRenderer.Pause();
                clothRenderer.Pause();
                shoeRenderer.Pause();
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

        public void AnimationHandler(PlayerState state, bool facingDir)
        {
            if (this.GetComponent<PlayerAnimations>() != null)
            {
                if (!facingDir && state == PlayerState.Running)
                {
                    ChangeAllRenderers(facingDir);

                    if (this.GetComponent<PlayerAnimations>().bodyRenderer.CurrentAnimationName != "Walking"
                        && this.GetComponent<PlayerAnimations>().bodyRenderer.CurrentAnimationName != "BasicAttack")
                    {
                        this.GetComponent<PlayerAnimations>().CheckAnimations(state);


                    }
                }

                if (state == PlayerState.Running && facingDir)
                {
                    ChangeAllRenderers(facingDir);

                    if (this.GetComponent<PlayerAnimations>().bodyRenderer.CurrentAnimationName != "Walking"
                        && this.GetComponent<PlayerAnimations>().bodyRenderer.CurrentAnimationName != "BasicAttack")
                    {
                        this.GetComponent<PlayerAnimations>().CheckAnimations(state);
                    }
                }

                if (state == PlayerState.Idle)
                {
                    if (this.GetComponent<PlayerAnimations>().bodyRenderer.CurrentAnimationName != "Idle"
                        && this.GetComponent<PlayerAnimations>().bodyRenderer.CurrentAnimationName != "BasicAttack")
                    {
                        this.GetComponent<PlayerAnimations>().CheckAnimations(state);
                    }
                }
            }
        }

        void ChangeAllRenderers(bool facing)
        {
            SpriteAnimator[] renderers = this.GetComponents<SpriteAnimator>().ToArray();

            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].FlipX = facing;
            }
        }
    }
}
