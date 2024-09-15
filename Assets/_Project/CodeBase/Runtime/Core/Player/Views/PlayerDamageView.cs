using PrimeTween;
using UnityEngine;

namespace Main.Assets._Project.CodeBase.Runtime.Core.Player.Views
{
    public class PlayerDamageView : MonoBehaviour
    {
        [SerializeField] private Transform _hitAnimationableObject;
        [SerializeField] private ShakeSettings _shakeSettings;

        public void VisualizeDamage()
        {
            if (_hitAnimationableObject != null)
                Tween.ShakeLocalPosition(_hitAnimationableObject, _shakeSettings);
        }

        private void OnDestroy()
        {
            if(_hitAnimationableObject != null)
                Tween.StopAll(_hitAnimationableObject);
        }
    }
}
