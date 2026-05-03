using UnityEngine;
using TMPro;

public class BeerTimer : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public TextMeshProUGUI TimerText;
    public GameObject gameOverView;


    void Update()
    {
        if (timeLeft < 0)
        {
            Time.timeScale = 0f;
            gameOverView.SetActive(true);
        }
        else
        {
            timeLeft -= Time.deltaTime;
            TimerText.text = (timeLeft).ToString("0");
        }
    }
} 