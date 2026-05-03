using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SisuManager.Instance.RestoreSceneStartCurrency();
        SceneManager.LoadScene(sceneName);
    }
}
