using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{

    public float timeLeft = 60.0f;
    public TextMeshProUGUI startText;
    public GameObject indicator;


    void Update()
    {
        if (timeLeft < 0)
        {
            indicator.SetActive(false);
        }
        else
        {
            timeLeft -= Time.deltaTime;
            startText.text = (timeLeft).ToString("0");
        }
    }
} 