using UnityEngine;
using Reflex.Core;
using Main.Assets._Project.CodeBase.Runtime.Core.Player;
using Main.Assets._Project.CodeBase.Runtime.Core.Player.Views;

namespace Main.Assets._Project.CodeBase.Runtime.Infrastructure.Installers
{
    public class PlayerInstaller : MonoBehaviour, IInstaller
    {
        [Header("Settings")]
        [SerializeField] private int _startMaxHealth;

        [Header("Views")]
        [SerializeField] private PlayerHealthView _playerHealthView;
        [SerializeField] private PlayerScoreView _playerScoreView;
        [SerializeField] private PlayerDamageView _playerDamageView;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            PlayerModel playerModel = new PlayerModel(_startMaxHealth);
            
            PlayerController playerController = new PlayerController(playerModel, _playerHealthView,
                    _playerScoreView, _playerDamageView);

            containerBuilder.AddSingleton(playerController);
        }
    }
}
