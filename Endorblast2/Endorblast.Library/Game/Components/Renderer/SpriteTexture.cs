using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Endorblast.Lib.Game.Renderer
{
    public class SpriteTexture
    {
        private Texture2D texture;
        public int Width, Height;
        private Vector2 position;
        private Vector2 centerPosition;
        private Vector2 scale;
        

        public Vector2 Position => position;
        public Vector2 Center => centerPosition;
        public Vector2 Scale => scale;

        private Rectangle rectangle;

        public Texture2D Texture => texture;


        public SpriteTexture(Texture2D texture)
        {
            this.texture = texture;
            Width = texture.Width;
            Height = texture.Height;
            scale = new Vector2(1, 1);

        }

        public void SetScale(int x, int y)
        {
            scale = new Vector2(x, y);
        }

    }
}