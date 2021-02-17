using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Endorblast.Lib.Game.Network;
using Lidgren.Network;
using Nez.Tiled;

namespace Endorblast.Lib
{
    
    


    public class KeyboardInputComp : Component, IUpdatable
    {
        public MoveState moveState;
        public MovementActionState actionState;
        public InputAction inputAction;

        Keys moveRightKey = Keys.D;
        Keys moveLeftKey = Keys.A;
        Keys jumpKey = Keys.Space;
        Keys slideKey = Keys.LeftShift;


        Vector2 OldPosition;

        private TiledMapMover.CollisionState collisionState;
        
        public bool IsMoving => 
            moveState == MoveState.MoveLeft || 
            moveState == MoveState.MoveRight;

        public bool OldPosIsPos =>
            Transform.Position.X == OldPosition.X &&
            Transform.Position.Y == OldPosition.Y;

        public KeyboardInputComp(bool isClient = true, bool isServer = false)
        {
            Initialize();
        }

        public void SetCollisionState(TiledMapMover.CollisionState coll)
        {
            collisionState = coll;
        }

        public void SetPlayerAction(MovementActionState state)
        {
            actionState = state;
        }

        public void SetInputAction(InputAction input)
        {
            inputAction = input;
        }
        
        public override void Initialize()
        {
            
        }

        public void Update()
        {
            moveState = MoveState.None;

            #region Movement Start
            
            if (Input.IsKeyDown(moveRightKey))
                moveState = MoveState.MoveRight;
            
            if (Input.IsKeyDown(moveLeftKey))
                moveState = MoveState.MoveLeft;

            if (Input.IsKeyDown(moveLeftKey) && Input.IsKeyDown(moveRightKey))
                moveState = MoveState.None;
            
            #endregion Movement End

            #region Action Movement Start
            
            if (Input.IsKeyPressed(slideKey) && collisionState.Below && actionState == MovementActionState.None)
                actionState = MovementActionState.Slide;

            if ((collisionState.Right || collisionState.Left) && !collisionState.Below && actionState == MovementActionState.None)
                actionState = MovementActionState.WallSlide; 
            
            
            if ((collisionState.Right || collisionState.Left) && collisionState.Below && actionState == MovementActionState.WallSlide || 
                (!collisionState.Right || !collisionState.Left) && collisionState.Below && actionState == MovementActionState.WallSlide)
                actionState = MovementActionState.None;
            
            

            #endregion Action Movement End


            #region Input Actions - Stuff the require other stuff from: MovementActionState or MoveState

            


            if (Input.IsKeyDown(jumpKey) && collisionState.Below)
                inputAction = InputAction.Jump;
            
            if (Input.IsKeyPressed(jumpKey) && (collisionState.Right || collisionState.Left) &&
                !collisionState.Below && actionState == MovementActionState.WallSlide)
                inputAction = InputAction.WallJump;


            #endregion


        }
    }
}