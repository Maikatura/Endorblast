using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib;
using Microsoft.Xna.Framework;
using Nez.BitmapFonts;

namespace EndorblastCore.Lib
{
    class CharacterManager
    {
        static CharacterManager instance = new CharacterManager();
        public static CharacterManager Instance => instance;

        public int CurrentWorldID = 0;

        public List<BasePlayer> Characters = new List<BasePlayer>();

        public BasePlayer GetConnection(int playerID)
        {
            foreach (var p in Characters)
                if (p.WorldID == playerID)
                {
                    Console.WriteLine(p.WorldID);
                    return p;
                }
                    

            return null;
        }

        public void AddPlayer(BasePlayer player, string username, float x, float y, int worldID)
        {
            player.WorldID = worldID;
            player.CharacterName = username;
            player.Transform.Position = new Vector2(x, y);
            Characters.Add(player);
            Console.WriteLine(player.CharacterName + " joined wolrd with ID:" + CurrentWorldID);
            CurrentWorldID++;
            
        }

        public void RemovePlayer(BasePlayer player)
        {

        }

        public void RemovePlayer(string chname)
        {
            var ch = Characters.Find(x => x.CharacterName == chname);

            if (ch.CharacterName != null)
            {
                Characters.Remove(ch);
                ch.Entity.Destroy();
            }

            Console.WriteLine("Removed character: " + ch.CharacterName);
        }

    }
}
