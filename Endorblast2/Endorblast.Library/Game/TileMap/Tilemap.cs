using System;
using System.Data;
using System.IO;
using Endorblast.Lib.Data;
using Endorblast.Lib.TileMap;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Endorblast.Lib.Game.TileMap
{
    public class Tilemap
    {
        
        public delegate void OnNewMapHandler(Map newMap);
        public event OnNewMapHandler NewMap;
        
        private Map myMap;


        private GraphicsDevice gd;
        private Maps currentEditMap = Maps.None;
        private Size2 viewportSize;
        private OrthographicCamera camera;
        public TilemapHelper tmHelper;
        

        public Maps EditMap
        {
            get => currentEditMap;
            set => currentEditMap = value;
        }


        public Tilemap(GraphicsDevice gd)
        {
            this.gd = gd;
            Init();
            CreateMap(10, 10, 32, 32);
        }

        public Tilemap(GraphicsDevice gd, Maps map)
        {
            this.gd = gd;
            Init();
            LoadMap(map);
        }

        void Init()
        {
            tmHelper = new TilemapHelper(gd, @"..\..\..\Content");
            camera = new OrthographicCamera(gd)
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

        public void UpdateMapSize(int mapWidth, int mapHeight, int tileWidth, int tileHeight)
        {
            myMap = new Map(tileWidth, tileHeight, mapWidth, mapHeight);
            NewMap?.Invoke(myMap);
        }
        
        public void SaveMap()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Data/Maps/"+ currentEditMap +".map";
            
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                myMap.Save(fs);
                fs.Close();
            }
        }

        public void LoadMap(Maps mapType)
        {
            currentEditMap = mapType;
            var path = AppDomain.CurrentDomain.BaseDirectory + "/Data/Maps/" + mapType + ".map";

            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    myMap = new Map(fs);
                    NewMap?.Invoke(myMap);
                    fs.Close();
                }
            }
            else
            {
                CreateMap(10, 10, 32, 32);
            }

        }

        public void Update(float dt)
        {
            
        }

        public void Draw(SpriteBatch sb, float dt)
        {
            myMap.Draw(sb, camera, tmHelper.Tilesets, tmHelper.Objects);
        }
    }
}