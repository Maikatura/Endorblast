using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Lib.Entities
{
    public class StaticCharacter
    {

        public NetConnection connection;
        public string AccountName;
        public string CharacterName;

        public string Name { get; set; }
        public int Level { get; set; }
        
        public float PosX { get; set; }
        public float PosY { get; set; }

        public int PlayerID { get; set; }
        public int WorldID { get; set; }

        public int Health { get; set; }
        public int Mana { get; set; }


        public StaticCharacter() { }

        public StaticCharacter(string name, int posX, int posY, int hp , int mana, int worldID, int playerID)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
            Health = hp;
            Mana = mana;
            WorldID = worldID;
            PlayerID = playerID;
        }

        public BasePlayer ToBasePlayer()
        {
            var bp = new BasePlayer();

            return bp;
        }

        // public Player ToServerPlayer()
        // {
        //     var sc = new Player();
        //
        //     
        //     sc.AccountName = AccountName;
        //     sc.CharacterName = CharacterName;
        //     sc.playerID = PlayerID;
        //     sc.WorldID = WorldID;
        //
        //     return sc;
        // }

    }

    
}
