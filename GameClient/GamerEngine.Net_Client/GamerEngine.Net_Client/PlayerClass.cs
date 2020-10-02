using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tiled;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerEngineNet_Client
{



    public class PlayerClass : Component, IUpdatable
    {
        public int connectionID;
        public bool isMyPlayer;

        float moveSpeed = 100;
        float gravity = 1000;
        float jumpHeight = 16 * 7;

        FollowCamera cam;

        Vector2 wantCameraPos;

        TiledMapMover mover;
        TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        BoxCollider boxCollider;
        Vector2 velocity;

        SpriteAnimator anim;

        bool isWalking = false;
        bool isIdle = true;

        UICanvas canvas;

        KeyboardInput keys;
        SubpixelVector2 subpixelV2 = new SubpixelVector2();


        public void InitAnim()
        {
            anim = this.AddComponent<SpriteAnimator>();

            Sprite player = new Sprite(Core.Content.LoadTexture("Content/Player/Base/Chara_Running.png"));
            Sprite[] walking = Sprite.SpritesFromAtlas(player, 64, 64).ToArray();

            Sprite idleSprite = new Sprite(Core.Content.LoadTexture("Content/Player/Base/Chara_Idle.png"));
            Sprite[] idle = Sprite.SpritesFromAtlas(idleSprite, 64, 64).ToArray();

            SpriteAnimation walkAnim = new SpriteAnimation(walking, 10);
            SpriteAnimation idleAnim = new SpriteAnimation(idle, 10);

            anim.AddAnimation("Walking", walkAnim);
            anim.AddAnimation("Idle", idleAnim);
        }

        public enum PlayerState
        {
            Idle,
            Walk
        }

        public PlayerClass(int ID, bool isMyPlayer)
        {
            this.connectionID = ID;
            this.isMyPlayer = isMyPlayer;
        }

        public override void OnAddedToEntity()
        {
            mover = this.GetComponent<TiledMapMover>();
            boxCollider = this.GetComponent<BoxCollider>();
            keys = this.GetComponent<KeyboardInput>();
            anim = this.GetComponent<SpriteAnimator>();
            InitAnim();
        }

        public void UpdatePlayerPos(Vector2 pos, bool isWalking, bool isIdle)
        {
            if (isMyPlayer)
            {
                if (Vector2.Distance(this.Transform.Position, pos) > 30f)
                {
                    this.Transform.Position = pos;
                }
            }
            else
            {
                this.Transform.Position = pos;

                CheckInputs(isWalking, isIdle);
            }
        }

        public void Update()
        {
            if (isMyPlayer)
            {
                if (cam == null)
                {
                    cam = this.GetComponent<FollowCamera>();
                    cam.Follow(this.Entity, FollowCamera.CameraStyle.LockOn);
                }

                if (keys != null)
                {
                    if (keys._inputs[0])
                    {
                        isIdle = false;
                        isWalking = true;
                        velocity.X = moveSpeed;
                    }
                    else if (keys._inputs[1])
                    {
                        isIdle = false;
                        isWalking = false;
                        velocity.X = -moveSpeed;
                    }
                    else
                    {
                        isIdle = true;
                        velocity.X = 0;
                    }

                    velocity.Y += gravity * Time.DeltaTime;


                    mover.Move(velocity * Time.DeltaTime, boxCollider, collisionState);
                    wantCameraPos = this.Entity.Transform.Position;
                    subpixelV2.Update(ref wantCameraPos);
                    cam.Camera.Transform.Position = wantCameraPos;


                    if (collisionState.Right || collisionState.Left)
                    {
                        velocity.X = 0;
                    }

                    if (collisionState.Below || collisionState.Above)
                    {
                        velocity.Y = 0;
                    }

                    CheckInputs(isWalking, isIdle);
                }
            }





            //this.Transform.Position = Vector2.Lerp(this.Transform.Position, wantPos, Time.DeltaTime * speed);
        }

        void CheckInputs(bool isRunning, bool isIdle)
        {
            if (anim != null)
            {
                if (isRunning && !isIdle)
                {
                    this.GetComponent<SpriteRenderer>().FlipX = false;

                    if (anim.CurrentAnimationName != "Walking")
                    {
                        anim.Play("Walking");
                    }
                }

                if (!isRunning && !isIdle)
                {
                    this.GetComponent<SpriteRenderer>().FlipX = true;

                    if (anim.CurrentAnimationName != "Walking")
                    {
                        anim.Play("Walking");
                    }
                }

                if (isIdle)
                {
                    if (anim.CurrentAnimationName != "Idle")
                    {
                        anim.Play("Idle");
                    }
                }
            }
        }

    }
}
