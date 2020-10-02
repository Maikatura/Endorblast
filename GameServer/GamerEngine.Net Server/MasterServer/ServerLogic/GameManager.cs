using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tiled;
using System.Collections.Generic;

namespace MasterServer
{
    class GameManager
    {
        public static Dictionary<int, Entity> playerList = new Dictionary<int, Entity>();

        public static void JoinGame(int connectionID, Player player)
        {
            player.inGame = true;
            NetworkSend.InstantiateNetworkPlayer(connectionID, player);
        }

        public static void CreatePlayer(int connectionID)
        {
            var entity = Core.Scene.CreateEntity("player");
            Sprite player = new Sprite(Core.Scene.Content.LoadTexture("player"));
            entity.AddComponent<SpriteRenderer>().Sprite = player;
            entity.AddComponent(new BoxCollider(16, 64));
            entity.AddComponent(new TiledMapMover(MasterScene.tiledLayer));

            entity.AddComponent(new Player()
            {
                connectionID = connectionID,
                inGame = true,
            });

            playerList.Add(connectionID, entity);

            JoinGame(connectionID, entity.GetComponent<Player>());

        }

        public static void DeletePlayer(int connectionID)
        {
            playerList[connectionID].Destroy();

            playerList.Remove(connectionID);


        }
    }
}
