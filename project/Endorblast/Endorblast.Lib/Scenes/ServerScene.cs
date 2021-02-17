using System.Collections.Generic;
using System.Net;
using Endorblast.Lib.GUI;
using Endorblast.LoginServer.Data;
using Endorblast.Lib.Discord;

namespace Endorblast.Lib.Scenes
{
    class ServerScene : BaseScene
    {
        private Dictionary<long, IPEndPoint[]> data;

        public ServerScene( Dictionary<long, IPEndPoint[]> data)
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