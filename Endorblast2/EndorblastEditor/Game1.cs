using System.Collections.Generic;
using Endorblast.DB.ImGui;
using Endorblast.DB.Lib;
using Endorblast.DB.Lib.Game.TileMap.Tilesets.Fuctions;
using Endorblast.DB.Lib.TileMap;
using Endorblast.Lib;
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
        private TilemapHelper tmHelper;

        private EditorImGui editor;
        
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

            Globals.gd = GraphicsDevice;
            Globals.sb = spriteBatch;
        }


        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            editor = new EditorImGui();
            ImGui.Elements.Add(editor.Main);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            
           
            editor.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            
            editor.Draw(spriteBatch, gameTime);
            
            
            spriteBatch.Begin();
            
            spriteBatch.End();

            ImGui.Draw(gameTime);
            
            base.Draw(gameTime);
    
            

        }
    }
}