using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Endorblast.Lib.Game.Renderer
{
    public class SpriteAnimator
    {
        private SpriteAnimation currentAnimation;
        private Dictionary<string, SpriteAnimation> animations = new Dictionary<string, SpriteAnimation>();

        private Vector2 scale;
        public Vector2 Scale => scale;
        

        public void AddAnimation(string animationName, SpriteAnimation animation)
        {
            animations.Add(animationName, animation);
            currentAnimation = animation;
        }

        public void RemoveAnimation(string animationName)
        {
            animations.Remove(animationName);
        }

        public void Update(float gt)
        {
            if (currentAnimation != null)
                currentAnimation.Update(gt);
        }
        
        public void Draw(SpriteBatch sb, float gt, Vector2 Position, Vector2 scale, float rotation)
        {
            if (currentAnimation != null)
                currentAnimation.Draw(sb, gt, Position, scale, rotation);
        }
        
        
    }
}