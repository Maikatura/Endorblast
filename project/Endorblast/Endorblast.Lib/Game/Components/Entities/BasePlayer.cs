using System;
using Microsoft.Xna.Framework;
using Nez;
using System.Collections.Generic;
using Endorblast.Lib.Skills;
using Nez.Tiled;
using Nez.Sprites;
using Lidgren.Network;
using Endorblast.Lib.Network;
using Endorblast.Lib.Enums;
using Endorblast.Lib.Game;


namespace Endorblast.Lib.Entities
{
    public class MoveBuffer
    {
        public float time; // Server Time sent.
        public float X; // Servers X Position of player
        public float Y; // Servers Y Position of player
        public MoveState state; // What state the player should be in.
        public MovementActionState MovementActionState;
    }

    public class BasePlayer : Component, IUpdatable
    {
        public MoveState OldMoveState = MoveState.None;
        public MoveState moveState = MoveState.None;
        public InputAction inputAction = InputAction.None;
        private MovementActionState actionState = MovementActionState.None;

        public float moveSpeed = 100;
        public float defaultSpeed = 100;
        public float sprintSpeed = 250;
        public float gravity = 1000;
        public float jumpHeight = 16 * 7;
        private float slideTimer = 0.3f;
        private float slideTime = 0.3f;
        private float slideForce;
        private float slideDuration = 0.3f;


        public int currentLobbyId;
        public int WorldID;

        public string Name;
        public string CharacterName;

        public bool isMainPlayer = false;
        public bool skillButtonUp = true;
        public FacingDirection currentDirection = FacingDirection.Right;

        public Vector2 OldPosition;
        public Vector2 latestDirection;
        public Vector2 direction;
        public Vector2 velocity;


        public NetConnection connection;

        public Skill currentSkill;


        public KeyboardInputComp Key;
        public PlayerAnimationsComp AnimationsComp;

        public TiledMapMover mover;
        public TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        public BoxCollider boxCollider;

        TextComponent name;


        // Network Prediction Stuff
        float correctionThreashold = 3f;
        public List<MoveBuffer> bufferMove = new List<MoveBuffer>();
        public MoveBuffer currentBuffer;
        public Skill skillBuffer = new Skill();

        private float gravityScale = 1;

        public bool OldPosIsPos =>
            Transform.Position.X == OldPosition.X &&
            Transform.Position.Y == OldPosition.Y;

        bool isInGame = false;


        public virtual void Update()
        {
            KeyInput();
            MovementPrediction();
            Movement();
            SkillBuffer();
            currentSkill?.Update();
        }

        public void DoSkill(SkillType type, BasePlayer player, float rotation)
        {
            if (currentSkill == null)
            {
                currentSkill = new Skill();
                currentSkill.ExitState();
            }

            if (currentSkill.isExiting)
            {
                currentSkill = Skill.DoSkill(type, player, rotation);
                if (isMainPlayer)
                    new CharacterSkillCastCommand().Send(type, rotation);
            }
        }


        public override void OnAddedToEntity()
        {
            InitComponents();
        }

        public virtual void InitComponents()
        {
            Key = this.GetComponent<KeyboardInputComp>();
            mover = this.GetComponent<TiledMapMover>();
            boxCollider = this.GetComponent<BoxCollider>();
            boxCollider.IsTrigger = true;

            Entity.Name = "Player";

            AnimationsComp = Entity.AddComponent(new PlayerAnimationsComp());
            AnimationsComp.LoadSet(1);
            AnimationsComp.LoadHair(1);
        }

        public void Jump()
        {
        }

        void KeyInput()
        {
            if (isMainPlayer)
            {
                Key.SetCollisionState(collisionState);
                moveState = Key.moveState;
                actionState = Key.actionState;
                inputAction = Key.inputAction;
                

                if (Key.IsMoving)
                {
                }
            }

            latestDirection = velocity;
            OldPosition = Transform.Position;


            switch (moveState)
            {
                case MoveState.MoveLeft:
                    velocity.X = moveSpeed;
                    currentDirection = FacingDirection.Left;
                    AnimationsComp.AnimationHandler(PlayerState.Running, currentDirection);
                    break;
                case MoveState.MoveRight:
                    velocity.X = moveSpeed;
                    currentDirection = FacingDirection.Right;
                    AnimationsComp.AnimationHandler(PlayerState.Running, currentDirection);
                    break;
                case MoveState.None:
                    velocity.X = 0;
                    AnimationsComp.AnimationHandler(PlayerState.Idle, currentDirection);
                    break;
            }

            

            

            switch (inputAction)
            {
                case InputAction.Jump:
                    velocity.Y = -Mathf.Sqrt((2 * PlayerSettings.jumpHeight * PlayerSettings.gravity) / gravityScale);
                    Key.SetInputAction(InputAction.None);
                    break;
                case InputAction.WallJump:
                    Key.SetInputAction(InputAction.None);
                    break;
            }
            
            switch (actionState)
            {
                case MovementActionState.Slide:
                    if (moveState == MoveState.None)
                    {
                        Key.SetPlayerAction(MovementActionState.None);
                    }
                    else
                    {
                        if (slideTimer >= 0)
                        {
                            AnimationsComp.AnimationHandler(PlayerState.Slide, currentDirection);
                            slideTimer -= Time.DeltaTime;
                            MoveCharacter(new Vector2(slideForce, 0));
                            slideForce = Mathf.Lerp(0, PlayerSettings.SlideForce, slideTimer);
                        }
                        else
                        {
                            Key.SetPlayerAction(MovementActionState.None);
                            slideTimer = slideTime;
                        }
                    }

                    break;
            }
        }



        public void Movement()
        {
            velocity.Y += gravity * Time.DeltaTime;
            MoveCharacter(velocity);

            if (collisionState.Right || collisionState.Left)
                velocity.X = 0;

            if (collisionState.Below || collisionState.Above)
                velocity.Y = 0;
        }

        public void MoveCharacter(Vector2 velocity)
        {
            if (currentDirection == FacingDirection.Left)
                mover.Move(new Vector2(-velocity.X, velocity.Y) * Time.DeltaTime, boxCollider, collisionState);
            else
                mover.Move(new Vector2(velocity.X, velocity.Y) * Time.DeltaTime, boxCollider, collisionState);
        }


        // (CLIENT AND SERVER) Basic Rubberbanding for Networking
        // Teleports player back to right position if its different from server.
        void MovementPrediction()
        {
            if (currentBuffer == null)
                return;

            MoveBuffer transmittedPacket = bufferMove.Find(x => x.time == currentBuffer.time);
            if (transmittedPacket == null)
                return;


            if (Vector2.Distance(Transform.Position, new Vector2(currentBuffer.X, currentBuffer.Y)) >
                correctionThreashold)
                Transform.Position = new Vector2(currentBuffer.X, currentBuffer.Y);

            moveState = currentBuffer.state;

            bufferMove.RemoveAll(x => x.time <= currentBuffer.time);
        }


        // (SERVER ONLY) Same as Method above. BUT....
        // Sometimes skills doesn't register on server therefore its need a buffergit
        void SkillBuffer()
        {
            if (currentSkill == null)
                return;

            if (skillBuffer == null)
                return;

            if (currentSkill.isExiting)
            {
                currentSkill = skillBuffer;
            }
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
        public BasePlayer()
        {
        }
        public BasePlayer(string name, NetConnection con)
        {
            this.Name = name;
            this.connection = con;
            isInGame = true;
        }
    }
}