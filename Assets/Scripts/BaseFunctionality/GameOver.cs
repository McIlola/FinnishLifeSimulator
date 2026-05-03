using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private PauseManager pauseManager;
    public void Begin()
    {
        gameOverScreen.SetActive(true);
        pauseManager.OtherPause();
    }
}
