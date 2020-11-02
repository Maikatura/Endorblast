using Lidgren.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Lib
{
    public class StaticCharacter
    {

        public NetConnection connection;
        public string AccountName;

        public string Name { get; set; }
        public int Level { get; set; }
        
        public float PosX { get; set; }
        public float PosY { get; set; }

        public int WorldID { get; set; }

        public int Health { get; set; }
        public int Mana { get; set; }


        public StaticCharacter() { }

        public StaticCharacter(string name, int posX, int posY, int hp , int mana)
        {
            Name = name;
            PosX = posX;
            PosY = posY;
            Health = hp;
            Mana = mana;
        }

        public BasePlayer ToBasePlayer()
        {
            var bp = new BasePlayer();

            return bp;
        }

    }
}
