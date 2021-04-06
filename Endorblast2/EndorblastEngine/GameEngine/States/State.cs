using System.Data;
using EndorblastEngine.GameEngine.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EndorblastEngine.GameEngine.States
{
    public abstract class State
    {

        protected Game1 _game;
        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;

        public State(Game1 game, ContentManager content, GraphicsDevice device)
        {
            _game = game;
            _content = content;
            _graphicsDevice = device;
        }

        public abstract void LoadContent();
        public abstract void Update(float gt);
        public abstract void PostUpdate(float gt);
        public abstract void Draw(float gt, SpriteBatch sb);

    }
}