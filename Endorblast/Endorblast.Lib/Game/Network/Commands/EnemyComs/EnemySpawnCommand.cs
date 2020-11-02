using Endorblast.Lib.Enums;
using Lidgren.Network;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endorblast.Lib.Game.Network.Commands
{
    public class EnemySpawnCommand
    {

        public void Read(NetIncomingMessage inc)
        {
            var enemy = new StaticEnemy();
            inc.ReadAllProperties(enemy);

            EnemyType type = enemy.Type;
            


            switch (type)
            {
                case EnemyType.Skeleton:

                    Entity test = new Entity("Tiddy");

                    test.AddComponent(new Skeleton());



                    
                    

                    test.Position = new Microsoft.Xna.Framework.Vector2(enemy.PosX, enemy.PosY);

                    Core.Scene.AddEntity(test);


                    break;
            }


        }


    }
}
