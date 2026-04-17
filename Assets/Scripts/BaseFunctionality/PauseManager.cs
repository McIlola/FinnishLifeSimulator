using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject PauseButton;
    public bool GamePaused = false;

    private void PauseGame()
    {
        GamePaused = true;
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
    }

    private void ResumeGame()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void TogglePause()
    {
        if (GamePaused)
            ResumeGame();
        else
            PauseGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}