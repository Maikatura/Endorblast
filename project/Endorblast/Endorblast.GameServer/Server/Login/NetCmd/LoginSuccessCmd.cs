using System;
using Endorblast.Lib.Enums;
using Endorblast.LoginServer.Login;
using Lidgren.Network;

namespace Endorblast.GameServer.Login
{
    public class LoginSuccessCmd
    {
        public void Send(NetConnection con, string username, int userID)
        {
            var outmsg = GameServerScript.Instance.CreateLoginMessage();
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
            
            GameServerScript.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered);
        }
    }
}