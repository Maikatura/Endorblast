using Nez;
using Nez.Sprites;
using Nez.Systems;

namespace Endorblast.Library
{
    public abstract class PlayerStateMachine
    {
        protected PlayerState currentState;

        public void SetState(PlayerState state)
        {
            currentState = state;
            currentState.Init();
        }
        
        public void Update()
        {
            currentState.Update();
        }

        public void Draw()
        {
            currentState.Draw();
        }
    }
}