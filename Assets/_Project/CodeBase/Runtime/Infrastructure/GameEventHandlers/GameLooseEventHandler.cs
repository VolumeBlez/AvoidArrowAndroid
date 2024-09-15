using Main.Assets._Project.CodeBase.Runtime.Core.Player;
using Reflex.Attributes;
using UnityEngine;

namespace Main.Assets._Project.CodeBase.Runtime.Infrastructure.GameEventHandlers
{
    public class GameLooseEventHandler : MonoBehaviour
    {
        [SerializeField] private Transform _deathParticleTargetCenter;
        [SerializeField] private ParticleSystem _deathParticle;
        private PlayerController _playerController;

        [Inject]
        public void Construct(PlayerController playerController)
        {
            _playerController = playerController;

            _playerController.PlayerReachedZeroHealth += OnLooseEventRaised;
        }

        public void OnLooseEventRaised()
        {
            _playerController.Disable();

            _deathParticle.transform.position = _deathParticleTargetCenter.position;
            _deathParticle.Play();
        }
    }
}
