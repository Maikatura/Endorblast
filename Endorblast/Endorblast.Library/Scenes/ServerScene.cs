using System.Collections.Generic;
using Endorblast.LoginServer.Data;
using Endorblast.Library.Discord;
using Endorblast.Library.GUI;

namespace Endorblast.Library.Scenes
{
    class ServerScene : BaseScene
    {
        private List<GameServerInfo> data;

        public ServerScene(List<GameServerInfo> data)
        {
            this.data = data;
        }
        
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();
            
            DiscordRpc.Instance.SetStatus($"EndorblastEngine Demo", "Server Selection");
            ServerSelectionUI.Instance.LoadUI(data);
        }
    }
}