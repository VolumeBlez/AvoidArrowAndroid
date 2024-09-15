using System;

namespace Main.Assets._Project.CodeBase.Runtime.Infrastructure.Services.TimerService
{
    public class Timer
    {
        public Action TimerComplete;

        private bool _isEnabled;

        public float Time { get; private set; }
        public float ElapsedTime { get; private set; }

        public void Update(float tick)
        {
            if (_isEnabled == false) return;

            ElapsedTime += tick;

            if (ElapsedTime >= Time)
            {
                _isEnabled = false;
                TimerComplete?.Invoke();
            }
        }

        public void Start(float time)
        {
            ElapsedTime = 0;
            Time = time;
            _isEnabled = true;
        }

        public void ForceStop()
        {
            _isEnabled = false;
        }
    }
}