using Reflex.Attributes;
using UnityEngine;

namespace Main.Assets._Project.CodeBase.Runtime.Core.Player.Systems
{
    public class PlayerDamageable : MonoBehaviour
    {
        private PlayerController _controller;

        [Inject]
        public void Construct(PlayerController controller)
        {
            _controller = controller;
        }

        public void ApplyDamage(int value)
        {
            _controller?.ApplyDamage(value);
        }
    }
}
