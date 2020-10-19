using Microsoft.Xna.Framework.Content;
using Nez;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer.Server.Game.Map
{
    public class MapManager
    {
        

        public long Seed { get; set; }

        public Map map;

        //CharacterManager cManager;

        public MapManager()
        {
            //cManager = CharacterManager.Instance;
        }

        public void GenerateMap(long seed = 0)
        {
            if (seed == 0)
                Seed = (long)Time.TotalTime;
            else
                Seed = seed;
        }

        public void GenerateMap(int lobbyId, MapType type, long seed = 0)
        {

            map = new Map(lobbyId);
            int w = 0;
            int h = 0;

            switch (type)
            {
                case MapType.Town:
                    w = 35;
                    h = 35;
                    
                    break;
                case MapType.Snowlands:
                    w = Nez.Random.Range(35, 50);
                    h = Nez.Random.Range(35, 50);
                    
                    break;
            }

            map.Setup(w, h);

            //WorldDataCommand.Send()
        }

        public void Update()
        {
            //cManager.Update();

        }

    }
}
