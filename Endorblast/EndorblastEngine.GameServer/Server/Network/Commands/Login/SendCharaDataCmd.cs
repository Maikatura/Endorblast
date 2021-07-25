using System;
using Endorblast.Backend.Tokens;
using Endorblast.DBase;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class SendCharaDataCmd : NetCmd
    {
        public void Read(NetIncomingMessage inc)
        {
            var token = inc.ReadString();

            var address = inc.SenderConnection.RemoteEndPoint.Address.ToString();
            var check = new VerifyToken().Validate(address, token);
            

            var username = check.Item1;
            var isRightToken = check.Item2;
            
            if (isRightToken == true)
            {
                var id = new AccountIDCmd().GetAccountID(username);
                Send(inc.SenderConnection, id);
            }
            else if (isRightToken == false)
            {
                //new SendErrorCmd().Send(inc.SenderConnection, ErrorCode.Error0200_TokenFailed);
            }
        }
        
        public void Send(NetConnection user, int id)
        {
            var list = new LoadCharactersDBCmd().LoadAllCharacters(id);

            var outmsg = netmana.GAMEMSG();
            outmsg.Write((byte)GamePacket.Logic);
            outmsg.Write((byte)GameLogicPacket.RequestCharacter);
            
            outmsg.Write(list.Count);

            for (int i = 0; i < list.Count; i++)
            {
                outmsg.WriteAllFields(list[i]);
            }
            
            
            
            

            server.SendMessage(outmsg, user, NetDeliveryMethod.ReliableOrdered);

        }
    }
}