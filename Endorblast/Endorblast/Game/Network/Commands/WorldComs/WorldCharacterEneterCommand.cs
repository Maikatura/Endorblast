using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Game.Network.NetCommands
{
    public class WorldCharacterEneterCommand : NetCommand
    {
        static event EventHandler<WorldCharacterEnterEvent> _Event;
        public static event EventHandler<WorldCharacterEnterEvent> Event
        {
            add
            {
                _Event = null;
                _Event += value;
            }
            remove
            {
                _Event -= value;
            }
        }

        public void Read(NetIncomingMessage msg)
        {
            var ch = new StaticCharacter();

            msg.ReadAllFields(ch);

            //_Event?.Invoke(this, new WorldCharacterEneterEvent(ch));
        }

        public void Send()
        {
            var outmsg = NetworkManager.Instance.CreateWorldMessage();
            //string name = NetworkManager.Instance.AccountName;

            outmsg.Write((byte)WorldPacket.CharacterEnter);
            //outmsg.Write(name);

            NetworkManager.Instance.client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);
        }
    }

    public class WorldCharacterEnterEvent : EventArgs
    {
        //var list = CharacterManager.Instance.GetConnections;
        //public WorldCharacterEnterEvent(LibCharacter ch)
        //{

        //}
    }



}
