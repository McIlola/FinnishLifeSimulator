using UnityEngine;

public class StartGameBouncer : MonoBehaviour
{    
    [SerializeField] private GameObject startGameScreen;
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private CountdownTimer countdownTimer;
    [SerializeField] private HandMovement playerMovement;
    [SerializeField] private GameObject soberMeter;

    public void Begin()
    {
        startGameScreen.SetActive(true);
        pauseManager.OtherPause();
    }

    public void StartButtonPressed()
    {
        startGameScreen.SetActive(false);
        pauseManager.OtherResume();
        playerMovement.movementEnabled = true;
        soberMeter.SetActive(true);
        countdownTimer.Begin();
    }
}
