using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject PauseButton;
    private bool otherPause;
    public bool GamePaused = false;

    private void PauseGame()
    {
        GamePaused = true;
        Time.timeScale = 0f;
        PauseScreen.SetActive(true);
        PauseButton.SetActive(false);
    }

    private void ResumeGame()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        PauseScreen.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void TogglePause()
    {
        if (GamePaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void OtherPause()
    {
        GamePaused = true;
        otherPause = true;
        Time.timeScale = 0f;
    }

    public void OtherResume()
    {
        otherPause = false;
        GamePaused = false;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (otherPause == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }
    }
}