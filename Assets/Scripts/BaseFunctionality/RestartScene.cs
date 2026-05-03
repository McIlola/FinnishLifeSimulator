using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartScene : MonoBehaviour
{
    public void RestartGame() 
    {
        SisuManager.Instance.RestoreSceneStartCurrency();
    	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
