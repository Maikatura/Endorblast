using Lidgren.Network;
using Nez;
using Endorblast.Library.Enemies;
using Endorblast.Library.Entities;
using Endorblast.Library.Enums;

namespace Endorblast.Library.Game.Network.Commands
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
