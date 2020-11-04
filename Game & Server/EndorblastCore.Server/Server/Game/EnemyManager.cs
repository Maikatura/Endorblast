using EndorblastCore.Lib;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndorblastCore.Server
{
    public class EnemyManager
    {
        static EnemyManager instance = new EnemyManager();
        public static EnemyManager Instance => instance;


        private List<Enemy> enemies = new List<Enemy>();
        public List<Enemy> Enemies => enemies;


        public void SpawnEnemyOnPoint(Vector2 dummySpawn)
        {
            Entity dummyThing = new Entity("DummyThingToTestWith");
            dummyThing.SetPosition(dummySpawn.X, dummySpawn.Y);
            var lol = dummyThing.AddComponent(new Skeleton());
            

            enemies.Add(lol);

            Core.Scene.AddEntity(dummyThing);
        }





    }
}
