using UnityEngine;

public class CutsceneAddBreathing : MonoBehaviour
{
    [SerializeField] private GameObject addBreathScreen;
    [SerializeField] private GameObject breathTracker;
    [SerializeField] private PauseManager pauseManager;

    public void Begin()
    {
        addBreathScreen.SetActive(true);
        pauseManager.OtherPause();
    }

    public void StartButtonPressed()
    {
        addBreathScreen.SetActive(false);
        breathTracker.SetActive(true);
        pauseManager.OtherResume();
    }
}
