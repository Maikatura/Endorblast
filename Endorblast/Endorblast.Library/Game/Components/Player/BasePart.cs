using Nez;
using Nez.Sprites;

namespace Endorblast.Library.Player
{
    public class BasePart : Component
    {

        protected SpriteAnimator part;


        

        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            part = Entity.AddComponent(new SpriteAnimator());
        }
    }
}