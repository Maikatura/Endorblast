using System;
using Endorblast.Backend.Tokens;
using Endorblast.LoginServer.Login.NetCmd;
using Lidgren.Network;
using MySqlX.XDevAPI.Common;

namespace Endorblast.Backend.ServerCmd
{
    public class CheckTokenFromClientCmd : MasterNet
    {


        public Tuple<string, bool> Read(NetIncomingMessage inc)
        {
            var token = inc.ReadString();
            var endPoint = inc.ReadIPEndPoint();
            var address = endPoint.Address.ToString();
            var result = new VerifyToken().Validate(address, token);

            
            
            var validToken = result.Item2;

            if (validToken == true)
                return result;
            
            return Tuple.Create("", false);
        }

    }
}