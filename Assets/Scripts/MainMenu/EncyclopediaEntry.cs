using UnityEngine;

public class EncyclopediaEntry : MonoBehaviour
{
    public string levelID;

    void Start()
    {
        if (!CompletedLevels.completedLevels.Contains(levelID))
        {
            gameObject.SetActive(false);
        }
    }
}
