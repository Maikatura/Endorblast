using System;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace Endorblast.Lib.Game.Components
{
    public class Zoom : SceneComponent, IUpdatable
    {
        private float zoomAmount = 0.125f; // In seconds
        private Camera camera;

        private float MinZoom = 1f;
        private float MaxZoom = 4f;
        
        public Zoom(Camera cam)
        {
            camera = cam;
            camera.MinimumZoom = MinZoom;
            camera.MaximumZoom = MaxZoom;
        }

        public override void Update()
        {
            base.Update();

            if (Input.MouseWheelDelta < 0)
            {
                camera.ZoomOut(zoomAmount);
            }
            else if (Input.MouseWheelDelta > 0)
            {
                camera.ZoomIn(zoomAmount);
            }
        }
    }
}