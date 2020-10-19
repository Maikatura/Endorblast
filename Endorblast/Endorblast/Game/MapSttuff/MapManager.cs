using Endorblast.Game.Network.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast
{
    public class MapManager
    {
        static MapManager instance = null;
        public static MapManager Instance => instance;
        public static void CreateInstance() { instance = new MapManager(); }

        public Map map;


        public MapManager()
        {
            map = new Map();

            WorldDataCommand.Event += WorldDataCommand_Event;
        }

        private void WorldDataCommand_Event(object sender, WorldDataEvent e)
        {

        }

        public void LoadMap(MapType type)
        {
            map = new Map();

            var pm = PlayerManager.Instance;
            pm.Players.Clear();
            EnemyManager.Instance.List.Clear();

            switch (type)
            {
                case MapType.Town:
                    // Generate Map
                    break;
                case MapType.Snowlands:
                    // Generate Map
                    break;
            }

            pm.Player.Transform.Position = map.Center;
        }


        void GenerateMap(MapType type)
        {
            map = new Map();
            //map.SetupMap(w, h);
        }
    }
}
