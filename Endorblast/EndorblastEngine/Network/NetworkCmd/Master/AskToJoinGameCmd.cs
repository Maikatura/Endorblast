using System;
using System.Net;
using Endorblast.Library;
using Endorblast.Library.Enums;
using Lidgren.Network;

namespace EndorblastEngine.Network.NetworkCmd.Master
{
    public class AskToJoinGameCmd : NetCommand
    {


        public void Send(string username, string token)
        {
            
            
            var outsmg = client.CreateMessage();
            outsmg.Write((byte)MasterServerMessageType.RequestToJoinGame);

            outsmg.Write(username);
            outsmg.Write(token);
            
            IPAddress mask;
            IPAddress adr = NetUtility.GetMyAddress(out mask);
            
            outsmg.Write(new IPEndPoint(adr, client.Port));

            client.SendUnconnectedMessage(outsmg, MasterSettings.Address, MasterSettings.Port);
        }
        
    }
}