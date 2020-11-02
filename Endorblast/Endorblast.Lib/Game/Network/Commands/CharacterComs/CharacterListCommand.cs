using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Endorblast.Lib;

namespace Endorblast.Lib.Network
{
    public class CharacterListEvent : EventArgs
    {
        public List<BasePlayer> Characters;
    

        public CharacterListEvent(List<StaticCharacter> list)
        {
            Console.WriteLine("CREATING LIST EVENT");

            
            Characters = new List<BasePlayer>();

            for (int i = 0; i < list.Count; i++)
            {
                var bp = list[i].ToBasePlayer();
                Characters.Add(bp);
            }
        }
    }


    class CharacterListCommand : NetCommand
    {
        public static event EventHandler<CharacterListEvent> CharacterListEvent;

        public void Read(NetIncomingMessage msg)
        {
            var list = new List<StaticCharacter>();
            NetworkManager.WorldID = msg.ReadInt32();
            PlayerManager.Instance.Player.WorldID = NetworkManager.WorldID;

            int count = msg.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                var lc = new StaticCharacter();
                msg.ReadAllProperties(lc);
                list.Add(lc);
            }
            Console.WriteLine("READ LIST MESSAGE");
            CharacterListEvent?.Invoke(this, new CharacterListEvent(list));
        }

        public void Send(NetIncomingMessage inc)
        {

        }
    }
}
