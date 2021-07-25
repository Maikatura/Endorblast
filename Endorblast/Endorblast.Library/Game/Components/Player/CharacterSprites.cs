using Nez;
using Nez.Sprites;

namespace Endorblast.Library.Player
{
    public class CharacterSprites : Component
    {
        private SpriteAnimator frontHead;
        private SpriteAnimator backHead;
        private SpriteAnimator head;
        private SpriteAnimator chest;
        private SpriteAnimator legs;
        private SpriteAnimator shoes;
        private SpriteAnimator cape;


        public override void OnAddedToEntity()
        {
            base.OnAddedToEntity();
            frontHead = Entity.AddComponent(new SpriteAnimator());
            backHead = Entity.AddComponent(new SpriteAnimator());
            head = Entity.AddComponent(new SpriteAnimator());
            chest = Entity.AddComponent(new SpriteAnimator());
            legs = Entity.AddComponent(new SpriteAnimator());
            shoes = Entity.AddComponent(new SpriteAnimator());
            cape = Entity.AddComponent(new SpriteAnimator());
        }
    }
}