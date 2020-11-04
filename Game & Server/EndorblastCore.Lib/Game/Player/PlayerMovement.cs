using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tiled;

namespace EndorblastCore.Lib
{

    public enum PlayerState
    {
        Idle,
        Running,
        IdlePause,
        BasicAttack,
    }

    

    public class PlayerMovement : Component, IUpdatable
    {
        float moveSpeed = 100;
        float defaultSpeed = 100;
        float sprintSpeed = 250;
        float gravity = 1000;
        float jumpHeight = 16 * 7;

        Player player;
        public PlayerState state;

        TiledMapMover mover;
        TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        BoxCollider boxCollider;
        FollowCamera cam;

        Vector2 wantCameraPos;
        Vector2 velocity;

        

        bool facingDir = true;

        KeyboardInput keys;


        public override void OnAddedToEntity()
        {
            mover = this.GetComponent<TiledMapMover>();
            boxCollider = this.GetComponent<BoxCollider>();
            keys = this.GetComponent<KeyboardInput>();
            player = this.GetComponent<Player>();

            InitAnim();
        }

        void InitAnim()
        {
            
        }

        public void Update()
        {

            if (player.isMyPlayer)
            {


                if (cam == null)
                {
                    cam = this.GetComponent<FollowCamera>();
                    cam.Follow(this.Entity, FollowCamera.CameraStyle.LockOn);
                    cam.Transform.Position = this.Entity.Position;
                }

                if (keys != null)
                {
                    if (keys.isSprinting)
                    {
                        moveSpeed = sprintSpeed;
                    }
                    else
                    {
                        moveSpeed = defaultSpeed;
                    }

                    if (keys.inputs[0] && keys.inputs[1])
                    {
                        state = PlayerState.Idle;
                        velocity.X = 0;
                    }
                    else if (keys.inputs[0] && !keys.inputs[1])
                    {
                        state = PlayerState.Running;
                        facingDir = false;
                        velocity.X = moveSpeed;
                    }
                    else if (keys.inputs[1] && !keys.inputs[0])
                    {
                        state = PlayerState.Running;
                        facingDir = true;
                        velocity.X = -moveSpeed;
                    }
                    else
                    {
                        state = PlayerState.Idle;
                        velocity.X = 0;
                    }

                    if (collisionState.Below && keys.inputs[2])
                    {
                        velocity.Y = -Mathf.Sqrt(2 * jumpHeight * gravity);
                    }

                    velocity.Y += gravity * Time.DeltaTime;


                    mover.Move(velocity * Time.DeltaTime, boxCollider, collisionState);
                    wantCameraPos = this.Entity.Transform.Position;
                    //subpixelV2.Update(ref wantCameraPos);
                    cam.Camera.Transform.Position = wantCameraPos;


                    if (collisionState.Right || collisionState.Left)
                    {
                        velocity.X = 0;
                    }

                    if (collisionState.Below || collisionState.Above)
                    {
                        velocity.Y = 0;
                    }

                    CheckInputs(facingDir);

                    //NetworkSend.SendPlayerPos(Transform.Position);
                }
            }
        }

        public void CheckPlayer(Vector2 pos, bool isWalking, bool facingDir)
        {
            if (this.GetComponent<Player>().isMyPlayer)
            {
                if (Vector2.Distance(this.Transform.Position, pos) > 75f)
                {
                    this.Transform.Position = pos;
                }
            }
            else
            {
                if (isWalking)
                {
                    state = PlayerState.Running;
                }
                if (!isWalking)
                {
                    state = PlayerState.Idle;
                }

                this.Transform.Position = pos;

                CheckInputs(facingDir);
            }
        }

        void CheckInputs(bool facingDir)
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

                if (facingDir && state == PlayerState.Running)
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
