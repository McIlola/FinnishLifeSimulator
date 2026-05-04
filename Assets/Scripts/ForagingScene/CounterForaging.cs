using UnityEngine;
using TMPro;

public class CounterForaging : MonoBehaviour
{
    public float timeRemaining = 60f;
    private TextMeshProUGUI countdownTimer;
    public GameObject gameOverScreen;
    [SerializeField] private PauseManager pauseManager;
    void Start()
    {
        countdownTimer = GetComponent<TextMeshProUGUI>();
    }

    void Update() 
    {
        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 0) 
        {
            timeRemaining = 0;
            EndGame();
        }

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        countdownTimer.text = $"{minutes:00}:{seconds:00}";
    }

    void EndGame()
    {
        gameOverScreen.SetActive(true);
        pauseManager.OtherPause();
    }
}
