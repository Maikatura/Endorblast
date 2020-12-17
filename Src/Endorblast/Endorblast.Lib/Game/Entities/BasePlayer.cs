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
    public enum PlayerMoveState
    {
        None,
        MoveLeft,
        MoveRight
    }

    public class MoveBuffer
    {
        public float time;                  // Server Time sent.
        public float X;                     // Servers X Position of player
        public float Y;                     // Servers Y Position of player
        public PlayerMoveState state;       // What state the player should be in.
    }

    public class BasePlayer : Component, IUpdatable
    {

        public PlayerMoveState OldMoveState = PlayerMoveState.None;
        public PlayerMoveState moveState = PlayerMoveState.None;

        public float moveSpeed = 100;
        public float defaultSpeed = 100;
        public float sprintSpeed = 250;
        public float gravity = 1000;
        public float jumpHeight = 16 * 7;

        public int currentLobbyId;
        public int WorldID;

        public string Name;
        public string CharacterName;

        public bool isMainPlayer = false;
        public bool skillButtonUp = true;
        public bool currentDirection = true;

        public Vector2 OldPosition;
        public Vector2 latestDirection;
        public Vector2 direction;
        public Vector2 velocity;



        public NetConnection connection;

        public Skill currentSkill;


        public KeyboardInput Key;
        public PlayerAnimations animations;

        public TiledMapMover mover;
        public TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        public BoxCollider boxCollider;

        TextComponent name;


        // Network Prediction Stuff
        float correctionThreashold = 3f;
        public List<MoveBuffer> bufferMove = new List<MoveBuffer>();
        public MoveBuffer currentBuffer;
        public Skill skillBuffer = new Skill();


        bool IsMoving => Key.MoveLeft || Key.MoveRight;

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
            Key = this.GetComponent<KeyboardInput>();
            mover = this.GetComponent<TiledMapMover>();
            boxCollider = this.GetComponent<BoxCollider>();
            boxCollider.IsTrigger = true;

            Entity.Name = "Player";
            
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


        // (CLIENT AND SERVER) Basic Rubberbanding for Networking
        // Teleports player back to right position if its different from server.
        void MovementPrediction()
        {
            if (currentBuffer == null)
                return;

            MoveBuffer transmittedPacket = bufferMove.Find(x => x.time == currentBuffer.time);
            if (transmittedPacket == null)
                return;


            if (Vector2.Distance(Transform.Position, new Vector2(currentBuffer.X, currentBuffer.Y)) > correctionThreashold)
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

        public BasePlayer() { }

        public BasePlayer(string name, NetConnection con)
        {
            this.Name = name;
            this.connection = con;
            isInGame = true;
        }
    }
}
