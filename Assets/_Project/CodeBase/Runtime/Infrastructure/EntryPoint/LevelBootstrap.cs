using Main.Assets._Project.CodeBase.Runtime.Core.Player;
using Main.Assets._Project.CodeBase.Runtime.Core.Player.Systems;
using Main.Assets._Project.CodeBase.Runtime.Infrastructure.Services.InputService;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Assets._Project.CodeBase.Runtime.Infrastructure.EntryPoint
{
    public class LevelBootstrap : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;

        private PlayerController _playerController;
        private InputHandler _input;

        [Inject]
        private void Construct(PlayerController playerController, InputHandler inputHandler)
        {
            _playerController = playerController;
            _input = inputHandler;
        }

        void Start()
        {
            _startGameButton.onClick.AddListener(OnGameButtonClicked);
        }

        private void OnGameButtonClicked()
        {
            _startGameButton.onClick.RemoveAllListeners();
            _startGameButton.gameObject.SetActive(false);

            _input.Init();

            _input.Enable();
            _playerController.Enable();
        }
    }
}