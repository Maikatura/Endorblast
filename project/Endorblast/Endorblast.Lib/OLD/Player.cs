
using Endorblast.Lib.Skills;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using Nez.Tiled;
using Nez.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Endorblast.Lib
{



    public class Player : Component, IUpdatable
    {
        public int connectionID;
        public int WorldID;
        public bool isMyPlayer;

        PlayerMovementComp movementComp;

        public Skill currentSkill;

        public Player(int ID, bool isMyPlayer)
        {
            this.connectionID = ID;
            this.isMyPlayer = isMyPlayer;
        }

        public override void OnAddedToEntity()
        {

            movementComp = this.GetComponent<PlayerMovementComp>();

        }



        public void Update()
        {
            if (isMyPlayer)
            {
                //LocalUpdate();
            }
        }

        

    }
}
