using Lidgren.Network;
using Nez.BitmapFonts;
using Nez.Svg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastServer
{
    class CharacterManager
    {
        static CharacterManager instance = new CharacterManager();
        public static CharacterManager Instance => instance;

        public int CurrentWorldID = 0;

        public List<SvCharacter> Characters = new List<SvCharacter>();

        public List<NetConnection> GetConnections(string chname)
        {
            var list = new List<NetConnection>();

            foreach (var p in Characters)
                if (p.Name != chname)
                    list.Add(p.connection);

            return list;
        }

        public List<NetConnection> GetConnections(int worldId)
        {
            var list = new List<NetConnection>();

            foreach (var p in Characters)
                if (p.WorldID != worldId)
                    list.Add(p.connection);


            return list;
        }

        public void AddPlayer(SvCharacter player)
        {
            player.WorldID = CurrentWorldID;
            Characters.Add(player);
            Console.WriteLine(player.Name + " joined wolrd with ID:" + CurrentWorldID);
            CurrentWorldID++;
        }

        public void RemovePlayer(int i, int pid)
        {
            Characters.RemoveAt(i);

            //new WorldRemoveCharacterCommand().Send(pid);
            Console.WriteLine("Removed character:" + pid);
        }

        public void RemovePlayer(SvCharacter sch)
        {
            var ch = Characters.Find(x => x.WorldID == sch.WorldID);
            if (ch != null)
                Characters.Remove(ch);

            //new WorldRemoveCharacterCommand().Send(sch.WorldID);

            Console.WriteLine("Removed character:" + sch.WorldID);
        }
    }
}
