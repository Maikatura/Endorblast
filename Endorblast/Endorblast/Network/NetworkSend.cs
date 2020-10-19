
using Microsoft.Xna.Framework;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using Microsoft.Xna.Framework.Input;

namespace Endorblast
{

    

    internal static class NetworkSend
    {

        public static void SendPlayerPos(Vector2 pos)
        {
            //NetOutgoingMessage msg = NetworkManager.Instance.CreateCharacterMessage();
            //msg.Write((byte)Packets.SendInput);
            //msg.Write((byte)pos.X);
            //msg.Write((byte)pos.Y);

            //client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
        }

        public static void SendKeys(Keys key)
        {
            //NetOutgoingMessage msg = NetworkManager.client.CreateMessage();
            //msg.Write((byte)Packets.SendInput);
            //msg.Write((byte)key);
            //NetworkManager.client.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
        }


    }
}
