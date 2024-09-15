using Main.Assets._Project.CodeBase.Runtime.Infrastructure.Services.InputService;
using Main.Assets._Project.CodeBase.Runtime.Infrastructure.Services.ReloadLevelService;
using Reflex.Core;
using UnityEngine;

namespace Main.Assets._Project.CodeBase.Runtime.Infrastructure.Installers
{
    public class LevelInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            InputHandler input = new();
            containerBuilder.AddSingleton(input);

            ReloadLevel reloadLevel= new ReloadLevel();
            containerBuilder.AddSingleton(reloadLevel);
        }
    }
}
