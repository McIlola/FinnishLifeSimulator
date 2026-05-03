using UnityEngine;
using TMPro;

public class CountdownTimer: MonoBehaviour {
    public float duration = 60f;
    public float timeRemaining;
    private TextMeshProUGUI countdownTimer;
    public bool isCountingDown = false;
    public GameObject gameOverScreen;
    [SerializeField] private CutsceneAddBreathing addBreathing;
    private bool breathingOnline = false;
    [SerializeField] private PauseManager pauseManager;

    void Start()
    {
        countdownTimer = GetComponent<TextMeshProUGUI>();
    }
    public void Begin()
    {
        timeRemaining = duration;
        isCountingDown = true;
    }

    void Update() 
    {
        if (!isCountingDown) return;

        timeRemaining -= Time.deltaTime;

        if (!breathingOnline && timeRemaining <= 46f)
        {
            breathingOnline = true;
            addBreathing.Begin();
        }

        if(timeRemaining <= 0) 
        {
            timeRemaining = 0;
            isCountingDown = false;
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