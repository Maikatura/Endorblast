using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace MasterServer
{
    class MouseScript : Component, IUpdatable
    {
        Point distance;
        
        Camera cam;
        float speed;

        private int previousScrollValue;

        float moveSpeed = 1;
        float shiftMoveSpeed = 3;
        float mouseWheelScroll = 0.05f;

        

        public void Update()
        {


            if (cam == null)
            {
                cam = Core.Scene.Camera;
                cam.Position = new Vector2(MasterScene.spawnPoint.X, MasterScene.spawnPoint.Y);
                
            }

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                speed = shiftMoveSpeed;
            }
            else
            {
                speed = moveSpeed;
            }

            if (Mouse.GetState().ScrollWheelValue < previousScrollValue)
            {

                cam.Zoom -= mouseWheelScroll;

            }
            else if (Mouse.GetState().ScrollWheelValue > previousScrollValue)
            {
                cam.Zoom += mouseWheelScroll;

            }

            if (Mouse.GetState().Position != distance && Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                
                float x = (Mouse.GetState().Position.X - distance.X);
                float y = (Mouse.GetState().Position.Y - distance.Y);
                cam.Position -= new Vector2(x, y);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                cam.Position = cam.Position + new Vector2(-speed, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                cam.Position = cam.Position + new Vector2(speed, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                cam.Position = cam.Position + new Vector2(0, -speed);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                cam.Position = cam.Position + new Vector2(0, speed);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                cam.Position = cam.Position + new Vector2(0, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                cam.Position = cam.Position + new Vector2(0, 0);
            }

            distance = Mouse.GetState().Position;
            previousScrollValue = Mouse.GetState().ScrollWheelValue;
        }
    }
}
