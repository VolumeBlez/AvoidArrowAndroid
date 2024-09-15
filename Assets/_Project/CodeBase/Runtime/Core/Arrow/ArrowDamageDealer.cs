using Main.Assets._Project.CodeBase.Runtime.Core.Player.Systems;
using UnityEngine;

namespace Main.Assets._Project.CodeBase.Runtime.Core.Arrow
{
    public class ArrowDamageDealer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerDamageable damageable))
            {
                damageable.ApplyDamage(1);
            }
        }
    }
}