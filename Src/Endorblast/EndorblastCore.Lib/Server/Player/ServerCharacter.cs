using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndorblastCore.Lib.GameObjects;

namespace EndorblastCore.Lib
{
    public class ServerCharacter
    {
        public string Name;
        public string CharacterName;
        public int currentLobbyId;
        public int playerID;
        public int WorldID;
        public NetConnection connection;

        public float X;
        public float Y;
        public PlayerMoveState State;

        public void Update()
        {
            // Todo : Validate everything the player does!
        }


        public void SetPosition(float x, float y, PlayerMoveState state)
        {
            X = x;
            Y = y;
            State = state;
        }
        
        
        public StaticCharacter ToStaticCharacter()
        {
            var lc = new StaticCharacter();

            lc.connection = this.connection;
            lc.Name = this.Name;
            lc.PlayerID = this.playerID;
            lc.WorldID = this.WorldID;

            return lc;
        }
    }
}
