using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private GameObject startGameScreen;
    [SerializeField] private PauseManager pauseManager;

    void Start()
    {
        startGameScreen.SetActive(true);
        pauseManager.OtherPause();
    }

    public void StartButtonPressed()
    {
        startGameScreen.SetActive(false);
        pauseManager.OtherResume();
    }
}
