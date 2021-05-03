using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Endorblast.Lib.Game.Data
{
    public class FrameCounter
    {
        public FrameCounter()
        {
        }
        
        public string FPS_STRING { get; private set; }

        public long TotalFrames { get; private set; }
        public float TotalSeconds { get; private set; }
        public float AverageFramesPerSecond { get; private set; }
        public float CurrentFramesPerSecond { get; private set; }

        public const int MAXIMUM_SAMPLES = 100;

        private Queue<float> _sampleBuffer = new Queue<float>();

        private float updateTime = 1;
        private float currentUpdateTime = 0;

        public bool Update(float deltaTime)
        {
            CurrentFramesPerSecond = 1.0f / deltaTime;

            _sampleBuffer.Enqueue(CurrentFramesPerSecond);
            

            if (_sampleBuffer.Count > MAXIMUM_SAMPLES)
            {
                _sampleBuffer.Dequeue();
                AverageFramesPerSecond = _sampleBuffer.Average(i => i);
            } 
            else
            {
                AverageFramesPerSecond = CurrentFramesPerSecond;
            }

            if (currentUpdateTime < 0)
            {
                currentUpdateTime = updateTime;
                FPS_STRING = $"{(int)AverageFramesPerSecond} FPS";
            }
            else
            {
                currentUpdateTime -= deltaTime;
            }

            TotalFrames++;
            TotalSeconds += deltaTime;
            return true;
        }
    }
}