using System;
using System.IO;
using Endorblast.DB.Lib.TileMap;
using Endorblast.Lib;
using EndorblastEditor;
using EndorblastEditor.Editor.Tools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Input;

namespace EndorblastEditor.TileMap
{
    public class Editor
    {

        private static Editor instance = new Editor();

        public static Editor Instance
        {
            get => instance;
            set => instance = value;
        }

        public delegate void OnNewMapHandler(Map newMap);
        public event OnNewMapHandler NewMap;

        private TilemapHelper tmHelper;
        public int ActiveLayer { get; set; } = 0;
        public PaintingTool ActivePaintingTool { get; set; }
        
        private Map myMap;
        private Size2 viewportSize;
        private OrthographicCamera camera;


        public Editor()
        {
            tmHelper = new TilemapHelper(Globals.gd, @"..\..\..\Content");
            CreateMap(10, 10, 32, 32);
            ActivePaintingTool = new TilePaintTool();

            camera = new OrthographicCamera(Globals.gd)
            {
                MinimumZoom = 0.25f,
                MaximumZoom = 1.25f
            };
        }
        
        public void CreateMap(int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            myMap = new Map(tileWidth, tileHeight, mapWidth, mapHeight);
            NewMap?.Invoke(myMap);
        }

        public void SaveMap(Stream stream)
        {
            myMap.Save(stream);
        }

        public void LoadMap(Stream stream)
        {
            myMap = new Map(stream);
            NewMap?.Invoke(myMap);
        }

        public void SetCollisionLayerVisible(bool visible)
        {
            myMap.CollisionLayer.Visible = visible;
        }

        public void Update(GameTime gameTime)
        {
            
            HandleViewportSizeChange();

            MouseStateExtended mouseState = MouseExtended.GetState();
            KeyboardStateExtended keyboardState = KeyboardExtended.GetState();
            Point mousePosition = mouseState.Position;
            Vector2 worldPosition = camera.ScreenToWorld(mousePosition.ToVector2());
            
            TileLayer.TilePositionDetail tilePositionDetail = myMap.GetTileAtPosition(worldPosition, ActiveLayer);
            CollisionLayer.CellPositionDetail cellPositionDetail = myMap.GetCellAtPosition(worldPosition);
            Tile tile = tilePositionDetail.Tile;
            
            if (mouseState.IsButtonDown(MouseButton.Right))
            {
                
                camera.Move(mouseState.DeltaPosition.ToVector2() / camera.Zoom);
            }
            else if (mouseState.DeltaScrollWheelValue != 0)
            {
                camera.Zoom = MathHelper.Clamp(camera.Zoom - mouseState.DeltaScrollWheelValue * 0.001f, camera.MinimumZoom, camera.MaximumZoom);
            }
            
            if (ActivePaintingTool != null)
            {
                if (ActivePaintingTool.IsValidPosition(myMap, keyboardState, tilePositionDetail, cellPositionDetail))
                {
                    if (mouseState.IsButtonDown(MouseButton.Left))
                    {
                        ActivePaintingTool.Paint(myMap, keyboardState, tilePositionDetail, cellPositionDetail);
                    }
                    else
                    {
                        ActivePaintingTool.Hover(myMap, keyboardState, tilePositionDetail, cellPositionDetail);
                    }
                }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            myMap.Draw(sb, camera, tmHelper.Tilesets);
        }

        private void HandleViewportSizeChange()
        {
            Size2 graphicsDeviceSize = new Size2(Globals.gd.Viewport.Width, Globals.gd.Viewport.Height);
            if (viewportSize != graphicsDeviceSize)
            {
                Vector2 cameraCenter = camera.Center;
                camera.Origin = new Vector2(graphicsDeviceSize.Width / 2, graphicsDeviceSize.Height / 2);
                camera.LookAt(cameraCenter);

                viewportSize = graphicsDeviceSize;
            }
        }
    }
}