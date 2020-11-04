using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Skills;
using Nez.Tiled;
using Nez.PhysicsShapes;
using Nez.Sprites;
using Microsoft.Xna.Framework.Input;
using Lidgren.Network;
using Endorblast.Lib.Network;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Game.Network;
using static Endorblast.Lib.Game.Network.CharacterSendInputCommand;

namespace Endorblast.Lib
{
    public enum PlayerMoveState
    {
        None,
        MoveLeft,
        MoveRight
    }


    public class BasePlayer : Component, IUpdatable
    {


        public PlayerMoveState moveState = PlayerMoveState.None;

        public float moveSpeed = 100;
        public float defaultSpeed = 100;
        public float sprintSpeed = 250;
        public float gravity = 1000;
        public float jumpHeight = 16 * 7;

        public string Name;

        public Vector2 OldPosition;
        public int WorldID;
        public string CharacterName;

        public bool isMainPlayer = false;

        public Vector2 latestDirection;
        public Vector2 direction;

        public NetConnection connection;

        public Skill currentSkill;
        public bool skillButtonUp = true;

        public bool currentDirection = true;

        public KeyboardInput Key;
        public PlayerAnimations animations;

        public TiledMapMover mover;
        public TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        public BoxCollider boxCollider;
        public List<PositionBuffer> bufferPos = new List<PositionBuffer>();
        public float lastTimeDiff;
        public float elapsedTime;

        public Vector2 velocity;
        Vector2 mouseInput;

        float SendPositionTimer;

        bool IsMoving => Key.MoveLeft || Key.MoveRight;

        public bool OldPosIsPos =>
            Transform.Position.X == OldPosition.X &&
            Transform.Position.Y == OldPosition.Y;

        bool isInGame;


        public virtual void Update()
        {

            KeyInput();
            Movement();
            currentSkill?.Update();
        }

        public void DoSkill(SkillType type, BasePlayer player, float rotation)
        {
            if (currentSkill != null)
            {
                if (currentSkill.isExiting)
                {
                    currentSkill = null;
                }
            }
            else
            {
                if (currentSkill == null)
                {
                    currentSkill = Skill.DoSkill(type, player, rotation);
                }
            }
        }

        public override void OnAddedToEntity()
        {
            Key = this.GetComponent<KeyboardInput>();
            mover = this.GetComponent<TiledMapMover>();
            boxCollider = this.GetComponent<BoxCollider>();

            animations = Entity.AddComponent(new PlayerAnimations());
            animations.LoadSet(2);
            animations.LoadHair(1);
        }


        void KeyInput()
        {


            if (isMainPlayer)
            {
                if (IsMoving)
                {
                    if (Key.MoveLeft)
                    {
                        moveState = PlayerMoveState.MoveRight;
                    }

                    if (Key.MoveRight)
                    {
                        moveState = PlayerMoveState.MoveLeft;
                    }
                }
                else
                {
                    moveState = PlayerMoveState.None;
                }

                if (!OldPosIsPos)
                {
                    if (SendPositionTimer > 0.015)
                    {
                        SendPositionTimer = 0;
                    }
                }
            }




            latestDirection = velocity;
            OldPosition = Transform.Position;


            if (moveState == PlayerMoveState.MoveLeft)
            {
                velocity.X = moveSpeed;
                currentDirection = false;
                animations.AnimationHandler(PlayerState.Running, currentDirection);
            }
            else if (moveState == PlayerMoveState.MoveRight)
            {
                velocity.X = -moveSpeed;
                currentDirection = true;
                animations.AnimationHandler(PlayerState.Running, currentDirection);
            }
            else if (moveState == PlayerMoveState.None)
            {
                velocity.X = 0;
                animations.AnimationHandler(PlayerState.Idle, currentDirection);
            }


        }

        public void Movement()
        {
         
            velocity.Y += gravity * Time.DeltaTime;

            mover.Move(velocity * Time.DeltaTime, boxCollider, collisionState);

            if (collisionState.Right || collisionState.Left)
            {
                velocity.X = 0;
            }

            if (collisionState.Below || collisionState.Above)
            {
                velocity.Y = 0;
            }

        }

        public void MoveCharacter(Vector2 velocity)
        {
            if (this.GetComponent<SpriteAnimator>().FlipX)
                mover.Move(-velocity * Time.DeltaTime, boxCollider, collisionState);
            else
                mover.Move(velocity * Time.DeltaTime, boxCollider, collisionState);
        }


        public StaticCharacter ToStaticCharacter()
        {
            var lc = new StaticCharacter();

            lc.connection = this.connection;
            lc.Name = this.Name;
            lc.WorldID = this.WorldID;
            lc.PosX = this.Transform.Position.X;
            lc.PosY = this.Transform.Position.Y;

            return lc;
        }

        public BasePlayer() { }

        public BasePlayer(string name, NetConnection con)
        {
            this.Name = name;
            this.connection = con;
            isInGame = true;
        }
    }
}
