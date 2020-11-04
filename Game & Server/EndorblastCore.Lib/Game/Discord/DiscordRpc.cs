using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Lib
{

    public class DiscordRpc
    {
        public DiscordRpcClient client;

        static DiscordRpc instance;
        public static DiscordRpc Instance => instance;
        public static void NewInstance() { instance = new DiscordRpc(); }


        public void Init()
        {
            client = new DiscordRpcClient("693045479457423402");
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };

            client.Initialize();

            client.SetPresence(new RichPresence()
            {
                Details = "Starting Game",
                State = "LOL",
                Assets = new Assets()
                {
                    LargeImageKey = "icon"
                }
            });
        }


        public void SetNewStatus(string details, string state = "Has not been set if you see this.")
        {
            client.SetPresence(new RichPresence()
            {
                Details = details,
                State = state,
                Assets = new Assets()
                {
                    LargeImageKey = "icon"
                }
            });
        }

    }
}
