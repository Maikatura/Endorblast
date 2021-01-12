using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Endorblast.Lib.Game.Player
{
    public class ParallaxBackgroundComp : Component, IUpdatable
    {


        private int currentBG = 0;

        Vector2 lastCameraPos;


        List<ParallaxBGSprite> backgrounds = new List<ParallaxBGSprite>();


        public ParallaxBackgroundComp(List<ParallaxBGSprite> lists)
        {

            currentBG = 0;
           

            foreach (var item in lists)
            {
                backgrounds.Add(item);
                item.renderer.SetRenderLayer(RenderLayers.BackgroundLayer);

                currentBG++;
            }




        }

        public void Update()
        {
            Vector2 deltaMovment = Core.Scene.Camera.Position - lastCameraPos;

            foreach (var item in backgrounds)
            {


                item.spriteObject.Transform.Position += new Vector2(deltaMovment.X * item.parallexSpeed,0);


                //Console.WriteLine(Math.Abs(myPlayer.Position.X - item.Transform.Position.X) >= textureUnitX);

                if (Math.Abs(Core.Scene.Camera.Position.X - item.spriteObject.Transform.Position.X) >= item.textureUnitX)
                {
                    float offsetX = (Core.Scene.Camera.Position.X - item.spriteObject.Transform.Position.X) % item.textureUnitX;

                    item.spriteObject.Transform.Position = new Vector2(Mathf.Round(Core.Scene.Camera.Position.X + offsetX), Mathf.Round(item.spriteObject.Transform.Position.Y));
                }
            }

            lastCameraPos = Core.Scene.Camera.Position;
        }

    }

    public class ParallaxBGSprite
    {
        public Entity spriteObject;
        public SpriteRenderer renderer { get; private set; }

        public float parallexSpeed { get; private set; }
        public float textureUnitX { get; private set; }
        public float textureUnitY { get; private set; }

        public ParallaxBGSprite(string path, float speed)
        {
            Sprite sprite = ContentLoader.LoadSprite(path);
            spriteObject = new Entity("ParallaxEffect-BG");
            spriteObject.Position = new Vector2(Mathf.Round(Core.Scene.Camera.Position.X), Mathf.Round(Core.Scene.Camera.Position.Y));
            
            renderer = spriteObject.AddComponent(new SpriteRenderer());
            renderer.SetSprite(sprite);
            

            textureUnitX = sprite.Texture2D.Width / 3;
            textureUnitY = sprite.Texture2D.Height / 3;
            parallexSpeed = speed;

            Core.Scene.AddEntity(spriteObject);
        }
    }
}
