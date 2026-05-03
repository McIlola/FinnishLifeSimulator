using UnityEngine;

public class StartGameDisplay : MonoBehaviour
{
    [SerializeField] private HandMovement playerMovement;
    [SerializeField] private GameObject startGameScreen;
    [SerializeField] private StartGameBouncer gameStart;

    void Start()
    {
        startGameScreen.SetActive(true);
    }

    public void StartButtonPressed()
    {
        startGameScreen.SetActive(false);
        playerMovement.movementEnabled = true;
        gameStart.StartButtonPressed();
    }
}
