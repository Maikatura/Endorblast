using System;
using Endorblast.DBase;
using Endorblast.Library.Enums;
using Endorblast.MasterServer;
using Lidgren.Network;

namespace Endorblast.LoginServer.Login.NetCmd
{
    public class LoginSuccessCmd
    {
        public void Send(NetConnection con, string username, int userID)
        {
            var outmsg = MasterServerScript.Instance.LOGINMSG();
            outmsg.Write((byte)LoginType.LoginSuccess);
            outmsg.Write(username);
            
            // Todo : Log login & Also make a unique identifier for client.

            Console.WriteLine(userID);
            var list = new LoadCharactersDBCmd().LoadAllCharacters(userID);

            if (list == null)
            {
                Console.WriteLine("### ERROR - Reading character database failed!");
                return;
            }
            
            outmsg.Write(list.Count);

            foreach (var character in list)
            {
                outmsg.WriteAllFields(character);
                Console.WriteLine(character.CharacterName);
            }
            
            MasterServerScript.Instance.Server.SendMessage(outmsg, con, NetDeliveryMethod.ReliableOrdered);
        }
    }
}