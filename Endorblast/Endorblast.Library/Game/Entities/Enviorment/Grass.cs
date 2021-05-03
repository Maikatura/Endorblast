using System;
using Endorblast.Library.Components;
using Microsoft.Xna.Framework;
using Nez;
using Random = Nez.Random;

namespace Endorblast.Library.GameObjects
{
    public class Grass : Entity
    {

        enum GrassType
        {
            LongGrass,
            ShortGrass,
        }
        
        public override void OnAddedToScene()
        {
            // int rng = Random.RNG.Next(0, 1);
            //
            // if (rng != 0)
            // {
            //     this.Destroy();
            //     return;
            // }
                
            // Random Type for grass
            Name = "Grass";
            
            GrassType random = (GrassType)Random.NextInt(Enum.GetNames(typeof(GrassType)).Length);
            string path = "";
            
            switch (random)
            {
                case GrassType.LongGrass:
                    Console.WriteLine("Long");
                    path = "/Textures/Misc/GameObjects/Grass/Grass2.png";
                    break;
                case GrassType.ShortGrass:
                    Console.WriteLine("Short");
                    path = "/Textures/Misc/GameObjects/Grass/Grass2.png";
                    break;
            }

            if (path == "")
            {
                Console.WriteLine("### ERROR : Grass Path is null.. Fix it");
                return;
            }
            
            var sprite = ContentLoader.LoadSprite(path);
            
            this.AddComponent(new GrassComp(sprite.Texture2D.Width, sprite.Texture2D.Height, sprite));
            

        }
        
        
        public void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}