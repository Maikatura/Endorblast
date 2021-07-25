using System;
using Microsoft.Xna.Framework;
using Nez.UI;

namespace Endorblast.Library
{
    public class TitleManager
    {
        private GameWindow window;
        private string windowTitle;

        internal static long drawCalls;
        TimeSpan _frameCounterElapsedTime = TimeSpan.Zero;
        int _frameCounter = 0;
        string _windowTitle;

        public TitleManager(GameWindow window, string windowTitle = "EndorblastEngine")
        {
            this.window = window;
            _windowTitle = windowTitle;
        }
        
        public void Update(GameTime gameTime)
        {
#if DEBUG
            // fps counter
            _frameCounter++;
            _frameCounterElapsedTime += gameTime.ElapsedGameTime;
            if (_frameCounterElapsedTime >= TimeSpan.FromSeconds(1))
            {
                var totalMemory = (GC.GetTotalMemory(false) / 1048576f).ToString("F");
                window.Title = string.Format("{0} {1} fps - {2} MB", _windowTitle, _frameCounter, totalMemory);
                _frameCounter = 0;
                _frameCounterElapsedTime -= TimeSpan.FromSeconds(1);
            }
#endif
        }
        
    }
}