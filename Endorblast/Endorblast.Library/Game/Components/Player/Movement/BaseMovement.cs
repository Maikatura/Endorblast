using System;
using System.Runtime.InteropServices;
using Endorblast.Library.Classes;
using Endorblast.Library.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Tiled;
using Nez.Tweens;

namespace Endorblast.Library.Movement
{
    public class BaseMovement : Component, IUpdatable
    {

        protected float movementSpeed = 120;
        protected float gravity = 1000;
        protected float jumpHeight = 112;
        
        private float jumpTimer = 0.2f;             // Change in BaseInput
        public float currentJumpTimer = 0;
        private float offGroundJump = 0.2f;
        private float currentOffGroundJump = 0;
        
        private bool hasTriggeredJump = false;
        private bool needMovementToWork = true;

        private ActionType _currentActionType = ActionType.Idle;
        private ActionType _lastActionType = ActionType.Idle;
        
        private MovementType _currentMovementType = MovementType.Idle;
        private MovementType _lastMovementType = MovementType.Idle;

        public TiledMapMover mover;
        public TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        public BoxCollider boxCollider;
        private Vector2 velocity = new Vector2();
        
        private SpriteAnimator spriteAnimator;
        private SpriteRenderer headSprite;
        public bool facing = true;

        private Entity saveEntity;        
        private BaseCharacterClass thisPlayerClass;
        private BaseInput playerInput;

        public float headAngle;
    
        
        public ActionType CurrentActionType
        {
            get => _currentActionType;
            set => _currentActionType = value;
        }
        public MovementType CurrentMoveType
        {
            get => _currentMovementType;
            set => _currentMovementType = value;
        }
        

        public BaseMovement()
        { }

        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            if (needMovementToWork == true)
            {
                // Default
                spriteAnimator = Entity.GetComponent<SpriteAnimator>();
                mover = Entity.GetComponent<TiledMapMover>();
                boxCollider = Entity.GetComponent<BoxCollider>();
                thisPlayerClass = Entity.GetComponent<BaseCharacterClass>();
                headSprite = Entity.AddComponent(new SpriteRenderer());
                Entity.TryGetComponent<BaseInput>(out playerInput);
                boxCollider.Width = 8;
                boxCollider.Height = 64;

                int layer = (int) RenderLayers.Layer.OtherPlayerMin; 
            
                spriteAnimator.SetRenderLayer(layer);
                spriteAnimator.LayerDepth = 0.5f;
                spriteAnimator.AddAnimation("main", thisPlayerClass.Sprites.GetSprites(_currentActionType));
                spriteAnimator.Play("main");
            
                // headSprite.SetRenderLayer(layer);
                // headSprite.LayerDepth = 0f;
                // var headTexture = thisPlayerClass.Sprites.GetHead();
                // headSprite.SetSprite(headTexture);
                // headSprite.SetLocalOffset(thisPlayerClass.Sprites.headOffset);
                // headSprite.SetOrigin(thisPlayerClass.Sprites.headSpriteOffset);
                
                currentJumpTimer = jumpTimer;
                currentOffGroundJump = offGroundJump; 
            }
            else
            {
                spriteAnimator = Entity.AddComponent(new SpriteAnimator());
                thisPlayerClass = Entity.GetComponent<BaseCharacterClass>();
                
                int layer = (int) RenderLayers.Layer.OtherPlayerMin;
            
                spriteAnimator.SetRenderLayer(layer);
                spriteAnimator.LayerDepth = 0.5f;
                spriteAnimator.AddAnimation("main", thisPlayerClass.Sprites.GetSprites(_currentActionType));
                spriteAnimator.Play("main");
            }
            
        }

        public void SetInput(MovementType movementType)
        {
            if (playerInput == null)
                return;

            _currentMovementType = movementType;
        }

        public void Update()
        {
            if (spriteAnimator == null || mover == null)
                return;
            
            if (playerInput != null)
                playerInput.Update();
           
            HeadMovement();
            MovementLogic();
            MovementState();

            UpdateSprite();
            Movement();
            
            _lastMovementType = _currentMovementType;
            _lastActionType = _currentActionType;
        }

        public void HeadMovement()
        {
            /*
            // Head Movement
            if (playerInput != null)
            {
                var mousePoint = Core.Scene.Camera.MouseToWorldPoint();
                
                float angleBetwennMouseAndEntity = 0f;
                float angleInDeg = 0f;
                float angleLimiter = 0f;
                float angleBackToRad = 0f;

                bool overLeftWindowMiddlePoint = mousePoint.X > 0;
                
                if (overLeftWindowMiddlePoint)
                {
                    
                    angleBetwennMouseAndEntity = Mathf.AngleBetweenVectors(Entity.Position, mousePoint);
                }
                else
                {
                    
                    angleBetwennMouseAndEntity = Mathf.AngleBetweenVectors(mousePoint, Entity.Position);
                }

                if (overLeftWindowMiddlePoint == true && headSprite.FlipX == true)
                    headSprite.FlipX = false;
                else if (overLeftWindowMiddlePoint == false && headSprite.FlipX == false)
                    headSprite.FlipX = true;
               

                    angleInDeg = Mathf.Rad2Deg * angleBetwennMouseAndEntity;
                angleLimiter = Mathf.Clamp(angleInDeg, -55, 55);
                angleBackToRad = Mathf.Deg2Rad * angleLimiter;
                
                headSprite.LocalRotation = angleBackToRad;
                //Console.WriteLine(mousePoint+" . "+headAngle+" . "+newHeadAngle+" . "+newNewHeadAngle+ " . "+ newNewNewHeadAngle);
            }*/
        }
        public void Movement()
        {
            velocity.Y += gravity * Time.DeltaTime;
            
            if (facing)
                mover.Move(new Vector2(-velocity.X, velocity.Y) * Time.DeltaTime, boxCollider, collisionState);
            else
                mover.Move(new Vector2(velocity.X, velocity.Y) * Time.DeltaTime, boxCollider, collisionState);

            if (collisionState.Right || collisionState.Left)
                velocity.X = 0;

            if (collisionState.Below || collisionState.Above)
            {
                velocity.Y = 0;

                if (collisionState.Below)
                {
                    hasTriggeredJump = false;
                    currentOffGroundJump = offGroundJump;
                }
            }
        }
        private void MovementLogic()
        {
            if (!collisionState.Below)
            {
                _currentActionType = ActionType.Jump;
            }
        }
        
        
        private void UpdateSprite()
        {
            spriteAnimator.FlipX = facing;

            if (_lastActionType != _currentActionType)
            {
                spriteAnimator.ReplaceAnimation("main", thisPlayerClass.Sprites.GetSprites(_currentActionType));
                spriteAnimator.Play("main");
            }
        }
        public void MovementState()
        {

            #region Movement Logic
            
            switch (_currentActionType)
            {
                case ActionType.Idle:
                    break;
                case ActionType.Walking:
                    break;
                case ActionType.Slide:
                    break;
                case ActionType.Jump:
                    spriteAnimator.Pause();
                    
                    int jumpFrame = 0;
                    
                    if (velocity.Y >= -100)
                        jumpFrame = 1;
                    
                    if (velocity.Y >= 150)
                        jumpFrame = 2;
                    
                    if (velocity.Y >= 400)
                        jumpFrame = 3;
                    
                    spriteAnimator.Sprite = thisPlayerClass.Sprites.GetSprites(ActionType.Jump).Sprites[jumpFrame];
                    
                    break;
                case ActionType.ArcherDefault:
                    break;
                case ActionType.ArrowStrike:
                    break;
                case ActionType.ShadowShot:
                    break;
                case ActionType.CripplingStrike:
                    break;
                case ActionType.WarriorDefault:
                    break;
                case ActionType.MageDefault:
                    break;
            }

            #endregion
            
            #region Movement Logic
            
            switch (_currentMovementType)
            {
                case MovementType.Idle:
                    // velocity.X = Mathf.Lerp(velocity.X, 0, Time.DeltaTime * 20);
                    velocity.X = 0;
                    break;
                case MovementType.Walking:
                    velocity.X = movementSpeed;
                    break;
                case MovementType.Slide:
                    break;
                case MovementType.Jump:
                    break;
                
                default:
                    _currentMovementType = MovementType.Idle;
                    break;
            }
            
            #endregion

            #region Logic Outside Switch
            
            currentJumpTimer -= Time.DeltaTime;
            currentOffGroundJump -= Time.DeltaTime;
            
            if ((currentJumpTimer > 0) && (currentOffGroundJump > 0) && !hasTriggeredJump)
            {
                velocity.Y = -Mathf.Sqrt(2 * jumpHeight * gravity);
                currentOffGroundJump = 0;
                currentJumpTimer = 0;
                hasTriggeredJump = true;
            }
            
            #endregion

        }

        public BaseMovement GetMovement(PlayerClassTypes type)
        {
            BaseMovement returnValue = null;
            
            switch (type)
            {
                case PlayerClassTypes.Archer:
                    returnValue = new WarriorMovement();
                    break;
                case PlayerClassTypes.Warrior:
                    returnValue = new WarriorMovement();
                    break;
                case PlayerClassTypes.Mage:
                    returnValue = new WarriorMovement();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return returnValue;
        }


        public BaseMovement(bool needMovement = true)
        {
            needMovementToWork = needMovement;
        }
    }
}