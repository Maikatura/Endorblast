using System.Collections.Generic;
using Endorblast.Lib.GUI;
using Endorblast.LoginServer.Data;
using Endorblast.Lib.Discord;

namespace Endorblast.Lib.Scenes
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
            
            DiscordRpc.Instance.SetStatus($"Endorblast Demo", "Server Selection");
            ServerSelectionUI.Instance.LoadUI(data);
        }
    }
}