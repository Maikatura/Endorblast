using Endorblast.Lib.Enums;
using Endorblast.Lib.GUI;
using Endorblast.Lib.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.DeferredLighting;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Endorblast.Lib.Scenes
{
    class TownScene : BaseScene
    {

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();

            SceneManager.InitGameMap(this, MapType.Town);
            DiscordRpc.Instance.SetStatus($"Character: {NetworkManager.CharacterName}", "World: Town");

            NetworkManager.Instance.State = NetworkState.InGame;
            new WorldCharacterEnterCommand().Send();

            InventoryUI.NewInstanse(this);
            GearUI.Instance.Init(this);
        }


       
    }
}
