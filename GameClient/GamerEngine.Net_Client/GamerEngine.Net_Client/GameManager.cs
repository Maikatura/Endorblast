using Microsoft.Xna.Framework;
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

namespace GamerEngineNet_Client
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
            var entity = activeScene.CreateEntity("player");

            if (isMyPlayer)
            {
                entity.AddComponent(new BoxCollider(16, 64));
                entity.AddComponent(new TiledMapMover(SceneManager.groundLayer));
                entity.AddComponent<FollowCamera>();
                Core.Scene.Camera.SetZoom(0.5f);
                entity.AddComponent(new PlayerClass(connectionID, isMyPlayer));
                entity.AddComponent(new KeyboardInput());
            }
            else
            {
                entity.AddComponent(new PlayerClass(connectionID, isMyPlayer));
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
