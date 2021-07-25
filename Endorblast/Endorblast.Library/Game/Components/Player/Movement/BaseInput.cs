using Endorblast.Library.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Endorblast.Library.Movement
{
    public class BaseInput : Component
    {
        private BaseMovement movement;
        public Vector2 mousePosition = new Vector2(0, 0);
        
        public BaseInput(BaseMovement movement)
        {
           this.movement = movement;
        }
        
        public void Update()
        {
            // Todo : Change every input here!
            if (Input.IsKeyDown(Keys.A) && !Input.IsKeyDown(Keys.D))
            {
                movement.facing = true;
                movement.CurrentActionType = ActionType.Walking;
                movement.CurrentMoveType = MovementType.Walking;
            }

            if (Input.IsKeyDown(Keys.D) && !Input.IsKeyDown(Keys.A))
            {
                movement.facing = false;
                movement.CurrentActionType = ActionType.Walking;
                movement.CurrentMoveType = MovementType.Walking;
            }

            if (!Input.IsKeyDown(Keys.A) && !Input.IsKeyDown(Keys.D))
            {
                movement.CurrentMoveType = MovementType.Idle;
                movement.CurrentActionType = ActionType.Idle;
            }

            if (Input.IsKeyDown(Keys.A) && Input.IsKeyDown(Keys.D))
            {
                movement.CurrentMoveType = MovementType.Idle;
                movement.CurrentActionType = ActionType.Idle;
            }

            if (Input.IsKeyPressed(Keys.Space))
            {
                
                movement.currentJumpTimer = 0.2f;
                movement.CurrentActionType = ActionType.Jump;
                movement.CurrentMoveType = MovementType.Jump;
                
            }

            // Head Movement
            {
                
                mousePosition = Input.MousePosition;
            }
        }
    }
}