using Endorblast.DB.ImGui;
using Endorblast.DB.Lib.Game.TileMap.Tilesets.Fuctions;
using EndorblastEditor.Editor.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace EndorblastEditor
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static ImguiComponent ImGui;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            ImGui = new ImguiComponent(graphics, this);     
            ImGui.fontSize = 8f;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            ImGui.Initialize();
            ImGui.LoadContent();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice); 
            ImGui.Elements.Add(new EditorImGui().Main);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //Your regular Game draw calls
            spriteBatch.End();

            ImGui.Draw(gameTime);
            
            base.Draw(gameTime);
    
            

        }
    }
}