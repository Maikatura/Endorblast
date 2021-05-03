using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Endorblast.Library.Game.Network;
using Lidgren.Network;
using Nez.Tiled;

namespace Endorblast.Library
{
    public enum MoveState
    {
        None,
        MoveLeft,
        MoveRight
    }

    public enum FacingDirection
    {
        Right,
        Left
    }

    public enum PlayerActionState
    {
        None,
        Slide,
        Jump,
        WallJump,
        WallSlide,
        EdgeHang
    }


    public class KeyboardInputComp : Component, IUpdatable
    {
        public MoveState moveState;
        public PlayerActionState actionState;

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

        public void SetPlayerAction(PlayerActionState state)
        {
            actionState = state;
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
            
            if (Input.IsKeyPressed(slideKey) && collisionState.Below && actionState == PlayerActionState.None)
                actionState = PlayerActionState.Slide;
            
            if (Input.IsKeyDown(jumpKey) && collisionState.Below && actionState == PlayerActionState.None)
                actionState = PlayerActionState.Jump;

            if (Input.IsKeyPressed(jumpKey) && 
                (collisionState.Left || collisionState.Right) && 
                !collisionState.Below && actionState == PlayerActionState.None)
                actionState = PlayerActionState.WallJump;
            
            #endregion Action Movement End

            //OldPosition = Transform.Position;
        }
    }
}