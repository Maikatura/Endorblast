using System;
using Endorblast.Lib.Enums;
using Endorblast.MasterServer;
using Lidgren.Network;

namespace Endorblast.LoginServer.Login.NetCmd
{
    public class LoginSuccessCmd
    {
        public void Send(NetConnection con, string username, int userID)
        {
            var outmsg = MasterServerScript.Instance.MASTERMSG();
            outmsg.Write((byte)MasterPacket.Login);
            outmsg.Write((byte)LoginPacket.LoginSuccess);
            outmsg.Write(username);
            
            // Todo : Log login & Also make a unique identifier for client.


            var list = Database.Instance.LoadAccountCharacters(userID);

            if (list == null)
            {
                Console.WriteLine("### ERROR - Reading character database failed!");
                return;
            }
            
            outmsg.Write(list.Count);

            foreach (var character in list)
            {
                outmsg.WriteAllFields(character);
                Console.WriteLine(character.Name);
            }
            
            MasterServerScript.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered);
        }
    }
}