using EndorblastServer.Server.NetCommands;
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

        public List<Endorblast.Lib.BasePlayer> Characters = new List<Endorblast.Lib.BasePlayer>();

        public List<NetConnection> GetConnections(string chname)
        {
            var list = new List<NetConnection>();

            foreach (var p in Characters)
                if (p.Name != chname)
                    list.Add(p.connection);

            return list;
        }

        public Endorblast.Lib.BasePlayer GetConnection(NetConnection con)
        {
            foreach (var p in Characters)
                if (con == p.connection)
                    return p;

            return null;
        }

        public List<NetConnection> GetConnections(int worldId)
        {
            var list = new List<NetConnection>();

            foreach (var p in Characters)
                if (p.WorldID != worldId)
                    list.Add(p.connection);


            return list;
        }

        public List<NetConnection> GetConnections()
        {
            var list = new List<NetConnection>();

            foreach (var p in Characters)
                list.Add(p.connection);


            return list;
        }

        public void AddPlayer(Endorblast.Lib.BasePlayer player)
        {
            player.WorldID = CurrentWorldID;
            Characters.Add(GameManager.Instance.AddPlayerToScene(player));
            Console.WriteLine(player.Name + " joined world with ID:" + CurrentWorldID);
            CurrentWorldID++;

            

        }

        public void RemovePlayer(int i, int pid)
        {
            Characters.RemoveAt(i);
            
            
            //new WorldRemoveCharacterCommand().Send(pid);
            Console.WriteLine("Removed character: " + pid);
            new WorldCharacterExitCommand().Send(i);
        }

        public void RemovePlayer(NetConnection con)
        {
            var ch = Characters.Find(x => x.connection == con);
            if (ch != null)
            {
                new WorldCharacterExitCommand().Send(ch.ToStaticCharacter());
                ch.Entity.Destroy();
                Characters.Remove(ch);
                Console.WriteLine("Removed character: " + ch.Name);
            }
            
            //Console.WriteLine("Removed character:" + pid);
        }

        public void RemovePlayer(BasePlayer sch)
        {
            var ch = Characters.Find(x => x.WorldID == sch.WorldID);
            if (ch != null)
            {
                new WorldCharacterExitCommand().Send(ch.ToStaticCharacter());
                ch.Entity.Destroy();
                Characters.Remove(ch);
                Console.WriteLine("Removed character: " + sch.WorldID);
            }

            
        }
    }
}
