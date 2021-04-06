using Endorblast.Lib.Data;
using Endorblast.Lib.Game.TileMap;
using Endorblast.Lib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EndorblastEngine.GameEngine.States
{
    public class GameState : State
    {
        public GameState(Game1 game, ContentManager content, GraphicsDevice device) : base(game, content, device)
        {
        }


        private Tilemap tile;
        
        public override void LoadContent()
        {
            
            tile = new Tilemap(_graphicsDevice, Maps.Town);
        }

        public override void Update(float gt)
        {
            tile.Update(gt);
        }

        public override void PostUpdate(float gt)
        {
            
        }

        public override void Draw(float gt, SpriteBatch sb)
        {
            tile.Draw(sb, gt);
        }
    }
}