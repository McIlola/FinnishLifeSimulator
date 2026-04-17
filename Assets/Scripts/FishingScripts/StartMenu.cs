using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject startGameScreen;
    public GameObject indicator;
    public GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
        indicator.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    public void StartButtonPressed()
    {
        startGameScreen.SetActive(false);
        Time.timeScale = 1f;
        indicator.SetActive(true);
        pauseMenu.SetActive(true);

    }
}
