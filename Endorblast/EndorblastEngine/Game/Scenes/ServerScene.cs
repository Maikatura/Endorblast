using System.Collections.Generic;
using Endorblast.LoginServer.Data;
using Endorblast.Library.Discord;
using Endorblast.Library.GUI;
using EndorblastEngine.Network;

namespace Endorblast.Library.Scenes
{
    class ServerScene : BaseScene
    {
        private List<ServerInfo> data;

        public ServerScene(List<ServerInfo> serverData)
        {
            
            new ServerSelectionUI().LoadUI(this, serverData);
        }
        
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();
            
            //DiscordRpc.Instance.SetStatus($"EndorblastEngine Demo", "Server Selection");
            
            
        }
    }
}