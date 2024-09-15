using UnityEngine;
using UnityEngine.UI;

namespace Main.Assets._Project.CodeBase.Runtime.Core.Player.Views
{
    public class PlayerScoreView : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        
        public void UpdateCount(int scoreCount)
        {
            _scoreText.text = "Score: " + scoreCount.ToString();
        }
    }
}
