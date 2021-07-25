using Nez;

namespace Endorblast.Library.Game.Components.Player
{
    public class UpdateSelectPosition : Component, IUpdatable
    {
        private float oldX = 0, oldY = 0;
        
        public void Update()
        {
            if (Screen.Center != Entity.Position)
                Entity.SetPosition(Screen.Center);
        }
    }
}