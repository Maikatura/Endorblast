namespace Endorblast.Lib.Enums
{
    
        public enum FacingDirection
        {
            Right,
            Left
        }

    
        public enum MoveState
        {
            None,
            MoveLeft,
            MoveRight
        }

    
        public enum MovementActionState
        {
            None,
            Slide,
            WallSlide,
            EdgeHang
        }

        public enum InputAction
        {
            None,
            Jump,
            WallJump
        }
    }