using Endorblast.Lib;
using Endorblast.Lib.Game.Data;
using EndorblastEngine.GameEngine.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EndorblastEngine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private State currentState;
        private State nextState;

        private FrameCounter counter = new FrameCounter();
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                SynchronizeWithVerticalRetrace = false,
                
            };

            Window.AllowUserResizing = true;
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = false;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            
            Globals.gd = GraphicsDevice;
            Globals.sb = spriteBatch;
            Globals.cm = Content;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            currentState = new GameState(this, Content, GraphicsDevice);
            currentState.LoadContent();
            nextState = null;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            
            
            counter.Update(deltaTime);
            Window.Title = $"Endorblast Game Engine [{counter.FPS_STRING}]";

            {
                if (nextState != null)
                {
                    currentState = nextState;
                    currentState.LoadContent();

                    nextState = null;
                }

                currentState.Update(deltaTime);
            }
            
            base.Update(gameTime);
        }

        public void ChangeState(State state)
        {
            nextState = state;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            var deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            currentState.Draw(deltaTime, spriteBatch);

            base.Draw(gameTime);
        }
    }
}