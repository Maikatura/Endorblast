using Endorblast;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tiled;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast
{
    public class GameManager
    {

        public static GameManager instance;

        public int connectionID;

        public Dictionary<int, Entity> playerList = new Dictionary<int, Entity>();
        public static Scene activeScene;
        public static Sprite player;


        public GameManager()
        {
            instance = this;
        }

        public void AddEntity(int connectionID, bool isMyPlayer)
        {
            playerList.Add(connectionID, CreateEntity(connectionID, isMyPlayer));
        }

        private Entity CreateEntity(int connectionID, bool isMyPlayer)
        {
            var entity = Core.Scene.CreateEntity("player");

            PlayerAnimations test = entity.AddComponent(new PlayerAnimations());
            test.LoadSet(2);
            test.LoadHair(1);
            
            

            TextComponent username = entity.AddComponent(new TextComponent());
            username.Text = "LOL";
            username.SetHorizontalAlign(HorizontalAlign.Center);
            username.SetVerticalAlign(VerticalAlign.Center);
            username.SetLocalOffset(new Vector2(0, -35));
            

            if (isMyPlayer)
            {
                
                entity.AddComponent(new BoxCollider(16, 64));
                entity.AddComponent(new TiledMapMover(SceneManager.groundLayer));
                entity.AddComponent<FollowCamera>();
                Core.Scene.Camera.SetZoom(0.5f);
                entity.AddComponent(new MainPlayer());
                entity.AddComponent(new Player(connectionID, isMyPlayer));
                entity.AddComponent(new PlayerMovement());
                entity.AddComponent(new KeyboardInput());
                entity.AddComponent<ActionBar>();

            }
            else
            {
                entity.AddComponent(new Player(connectionID, isMyPlayer));
                entity.AddComponent(new PlayerMovement());
            }

            

            return entity;
        }

        public void RemoveEntity(int connectionID)
        {
            playerList[connectionID].Destroy();
            playerList.Remove(connectionID);
        }

    }
}
