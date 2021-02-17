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
using Endorblast.Lib.Entities;

namespace Endorblast.Lib
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
            //playerList.Add(connectionID, CreateEntity(connectionID, isMyPlayer));
        }

        public BasePlayer CreateEntity(int connectionID,string username, bool isMyPlayer)
        {
            var entity = Core.Scene.CreateEntity("player");

            TextComponent usernameText = entity.AddComponent(new TextComponent());
            usernameText.Text = username;
            usernameText.SetHorizontalAlign(HorizontalAlign.Center);
            usernameText.SetVerticalAlign(VerticalAlign.Center);
            usernameText.SetLocalOffset(new Vector2(0, -35));
            usernameText.SetRenderLayer(RenderLayers.FrontObjectLayer);


            if (isMyPlayer)
            {

                var collider = entity.AddComponent(new BoxCollider(16, 64));
                collider.IsTrigger = true;
                entity.AddComponent(new TiledMapMover(SceneManager.groundLayer));
                entity.AddComponent(new FollowCamera());
                Core.Scene.Camera.SetZoom(0.5f);
                entity.AddComponent(new MainPlayer());
                entity.AddComponent(new KeyboardInputComp());

                //entity.AddComponent<ActionBar>();

            }
            else
            {
                entity.AddComponent(new BoxCollider(16, 64));
                entity.AddComponent(new TiledMapMover(SceneManager.groundLayer));
                entity.AddComponent(new BasePlayer());
                entity.AddComponent(new KeyboardInputComp(false));
            }

            

            return entity.GetComponent<BasePlayer>();
        }

        public void RemoveEntity(int connectionID)
        {
            playerList[connectionID].Destroy();
            playerList.Remove(connectionID);
        }

    }
}
