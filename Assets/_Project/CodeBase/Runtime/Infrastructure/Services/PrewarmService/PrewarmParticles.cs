using UnityEngine;

namespace Main.Assets._Project.CodeBase.Runtime.Infrastructure.Services.PrewarmService
{
    public class PrewarmParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        void Start()
        {
            _particleSystem.transform.position = new Vector3(0, 150, 0);
            _particleSystem.Play();
        }
    }
}
