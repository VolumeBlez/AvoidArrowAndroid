using UnityEngine.SceneManagement;

namespace Main.Assets._Project.CodeBase.Runtime.Infrastructure.Services.ReloadLevelService
{
    public class ReloadLevel
    {
        public void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
