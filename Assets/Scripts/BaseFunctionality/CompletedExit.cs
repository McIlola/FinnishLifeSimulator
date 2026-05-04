using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedExit : MonoBehaviour
{
    public string levelID;

    public void CompleteLevel()
    {
        CompletedLevels.completedLevels.Add(levelID);
        SceneManager.LoadScene("Main menu");
    }
}
