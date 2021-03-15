using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Num = System.Numerics;

namespace Endorblast.DB.ImGui
{
    public class SampleProject : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ImguiComponent ImGui;
  
        public SampleProject()
        {
            _graphics = new GraphicsDeviceManager(this);
            ImGui = new ImguiComponent(_graphics, this);     
            //if you have a theme set the theme ->
            //ImGui.Theme = CoolTheme;
            // ImGui.Font = @"Assets/font.ttf";
            ImGui.fontSize = 8f;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            ImGui.Initialize();
            ImGui.LoadContent();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            this.ImGui.Elements.Add(new ImGuiDemo(this.ImGui._imGuiTexture).Main);
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

            ImGui.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
