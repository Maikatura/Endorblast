using System;
using Endorblast.Library.Classes;
using Endorblast.Library.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Tiled;

namespace Endorblast.Library.Movement
{
    public class BaseMovement
    {
        private float gravity = 1000;
        private float jumpHeight = 16 * 7;
        
        private float jumpTimer = 0.2f;             // Change in BaseInput
        public float currentJumpTimer = 0;
        private float offGroundJump = 0.2f;
        private float currentOffGroundJump = 0;
        
        private bool hasTriggeredJump = false;

        private ActionType _currentActionType = ActionType.Idle;
        private ActionType _lastActionType = ActionType.Idle;
        
        private MovementType _currentMovementType = MovementType.Idle;
        private MovementType _lastMovementType = MovementType.Idle;

        public TiledMapMover mover;
        public TiledMapMover.CollisionState collisionState = new TiledMapMover.CollisionState();
        public BoxCollider boxCollider;
        private Vector2 velocity = new Vector2();
        
        private SpriteAnimator spriteAnimator;
        public bool facing = true;

        
        private BaseCharacterClass thisPlayerClass;
        private BaseInput playerInput;
    
        
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
        

        public BaseMovement(Entity entity, BaseCharacterClass player)
        {
            thisPlayerClass = player;
            playerInput = new BaseInput(this);
            
            mover = entity.GetComponent<TiledMapMover>();
            boxCollider = entity.GetComponent<BoxCollider>();
            spriteAnimator = entity.AddComponent(new SpriteAnimator());
            
            
            int layer = RenderLayers.OtherPlayersLayer; 
            spriteAnimator.SetRenderLayer(layer);

            spriteAnimator.AddAnimation("main", player.Sprites.GetSprites(_currentActionType));
            spriteAnimator.Play("main");


            currentJumpTimer = jumpTimer;
            currentOffGroundJump = offGroundJump;
        }

        public void Update()
        {
            playerInput.Update();
            Movement();
            MovementLogic();
            MovementState();
            
            UpdateSprite();
            _lastMovementType = _currentMovementType;
            _lastActionType = _currentActionType;
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
                    velocity.X = 0;
                    break;
                case MovementType.Walking:
                    velocity.X = 120;
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
    }
}