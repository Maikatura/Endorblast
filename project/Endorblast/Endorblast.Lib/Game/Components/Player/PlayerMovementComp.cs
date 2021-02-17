using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tiled;

namespace Endorblast.Lib
{

    public enum PlayerState
    {
        Idle,
        Running,
        IdlePause,
        BasicAttack,
        Slide,
        WallSlide,
    }

    

    public class PlayerMovementComp : Component, IUpdatable
    {
        float moveSpeed = 100;
        float defaultSpeed = 100;
        float sprintSpeed = 250;
        float gravity = 1000;
        float jumpHeight = 16 * 7;

        
        public PlayerState state;

        TiledMapMover mover;
        TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        BoxCollider boxCollider;
        FollowCamera cam;

        Vector2 wantCameraPos;
        Vector2 velocity;

        

        bool facingDir = true;

        KeyboardInputComp keys;


        public override void OnAddedToEntity()
        {
            mover = this.GetComponent<TiledMapMover>();
            boxCollider = this.GetComponent<BoxCollider>();
            keys = this.GetComponent<KeyboardInputComp>();
            

            InitAnim();
        }

        void InitAnim()
        {
            
        }

        public void Update()
        {

           


                
            
        }

        public void CheckPlayer(Vector2 pos, bool isWalking, bool facingDir)
        {
            
        }

        void CheckInputs(bool facingDir)
        {
            if (this.GetComponent<PlayerAnimationsComp>() != null)
            {
                if (!facingDir && state == PlayerState.Running)
                {
                    ChangeAllRenderers(facingDir);

                    if (this.GetComponent<PlayerAnimationsComp>().bodyRenderer.CurrentAnimationName != "Walking" 
                        && this.GetComponent<PlayerAnimationsComp>().bodyRenderer.CurrentAnimationName != "BasicAttack")
                    {
                        this.GetComponent<PlayerAnimationsComp>().CheckAnimations(state);


                    }
                }

                if (facingDir && state == PlayerState.Running)
                {
                    ChangeAllRenderers(facingDir);

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
            }
        }

        public void MoveCharacter(Vector2 velocity)
        {
            if (this.GetComponent<SpriteAnimator>().FlipX)
            {
                mover.Move(-velocity * Time.DeltaTime, boxCollider, collisionState);
            }
            else
            {
                mover.Move(velocity * Time.DeltaTime, boxCollider, collisionState);
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
