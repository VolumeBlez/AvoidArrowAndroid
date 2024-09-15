
using UnityEngine;
using UnityEngine.UI;

namespace Main.Assets._Project.CodeBase.Runtime.Core.Player.Views
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;
        private int _startHealth;

        public void Init(int startHealth)
        {
            _startHealth = startHealth;

            _healthImage.fillAmount = 1;
        }

        public void UpdateCount(int count)
        {
            _healthImage.fillAmount = (float)count / _startHealth;
        }
    }
}
