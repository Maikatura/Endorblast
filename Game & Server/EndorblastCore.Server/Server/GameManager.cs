using Endorblast;
using EndorblastCore.Lib;
using EndorblastCore.Server;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Server
{
    class GameManager
    {

        static GameManager instance = new GameManager();
        public static GameManager Instance => instance;


        public EndorblastCore.Lib.BasePlayer AddPlayerToScene(EndorblastCore.Lib.BasePlayer player)
        {
            Entity newPlayer = new Entity(player.Name);

            TextComponent username = newPlayer.AddComponent(new TextComponent());
            username.Text = player.Name;
            username.SetHorizontalAlign(HorizontalAlign.Center);
            username.SetVerticalAlign(VerticalAlign.Center);
            username.SetLocalOffset(new Vector2(0, -35));



            newPlayer.AddComponent(new BoxCollider(16, 64));
            newPlayer.AddComponent(new TiledMapMover(MapManager.Instance.map.ground));
            newPlayer.AddComponent(new KeyboardInput(false, true));
            newPlayer.AddComponent(player);
            newPlayer.AddComponent(new PlayerStats());

            Core.Scene.AddEntity(newPlayer);

            return newPlayer.GetComponent<EndorblastCore.Lib.BasePlayer>();
        }

        public void UpdatePlayerMovement()
        {

        }


    }
}
