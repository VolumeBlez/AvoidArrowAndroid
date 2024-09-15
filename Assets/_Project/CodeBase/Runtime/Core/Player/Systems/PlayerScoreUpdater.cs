using Main.Assets._Project.CodeBase.Runtime.Infrastructure.Services.TimerService;
using Reflex.Attributes;
using UnityEngine;

namespace Main.Assets._Project.CodeBase.Runtime.Core.Player.Systems
{
    public class PlayerScoreUpdater : MonoBehaviour
    {
        [SerializeField] private float _timeBetweenScoreIncrease;

        private PlayerController _controller;
        private Timer _timer;

        [Inject]
        public void Construct(PlayerController controller)
        {
            _controller = controller;
        }

        private void Start()
        {
            _timer = new Timer();
            _timer.TimerComplete += OnTimerComplete;
            
            _timer.Start(_timeBetweenScoreIncrease);
        }

        private void OnDestroy() => _timer.TimerComplete -= OnTimerComplete;

        private void Update() => _timer.Update(Time.deltaTime);

        private void OnTimerComplete()
        {
            _controller?.AddScore(1);
            _timer.Start(_timeBetweenScoreIncrease);
        }
    }
}
