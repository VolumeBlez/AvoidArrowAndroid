using Main.Assets._Project.CodeBase.Runtime.Infrastructure.Services.ReloadLevelService;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Assets._Project.CodeBase.Runtime.Infrastructure.GameEventHandlers
{
    public class ReloadEventHandler : MonoBehaviour
    {
        [SerializeField] Button _reloadButton;
        private ReloadLevel _reloadLevelService;

        [Inject]
        private void Construct(ReloadLevel reloadLevelService)
        {
            _reloadLevelService = reloadLevelService;
        }

        private void Start() => _reloadButton.onClick.AddListener(OnReloadButtonClicked);

        private void OnDestroy() => _reloadButton.onClick.RemoveAllListeners();

        private void OnReloadButtonClicked() => _reloadLevelService.Reload();
    }
}
