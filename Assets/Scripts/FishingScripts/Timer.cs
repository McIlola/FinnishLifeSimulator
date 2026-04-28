using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Diagnostics;

public class StartGame : MonoBehaviour
{

    public float timeLeft = 60.0f;
    public TextMeshProUGUI startText;
    public GameObject indicator;
    public GameObject gameOverView;


    void Update()
    {
        if (timeLeft < 0)
        {
            Time.timeScale = 0f;
            indicator.SetActive(false);
            gameOverView.SetActive(true);
        }
        else
        {
            timeLeft -= Time.deltaTime;
            startText.text = (timeLeft).ToString("0");
        }
    }
} 