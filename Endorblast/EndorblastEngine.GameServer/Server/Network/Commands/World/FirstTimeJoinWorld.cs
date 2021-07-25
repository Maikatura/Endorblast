using System;
using Endorblast.Backend.Tokens;
using Lidgren.Network;

namespace Endorblast.GameServer.NetworkCmd
{
    public class FirstTimeJoinWorld : NetCmd
    {


        public void Read(NetIncomingMessage inc)
        {
            var token = inc.ReadString();
            var result = new VerifyToken().Validate(inc.SenderEndPoint.Address.ToString(), token);

            if (result.Item2 == false)
                return;
        }
        


        public void Send()
        {
            
        }
    }
}