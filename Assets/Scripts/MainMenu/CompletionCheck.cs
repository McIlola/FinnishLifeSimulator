using UnityEngine;

public class CompletionCheck : MonoBehaviour
{
    public string[] requiredLevels;
    [SerializeField] private GameObject finalLevel;

    void Start()
    {
        foreach (string level in requiredLevels)
        {
            if (!CompletedLevels.completedLevels.Contains(level))
            {
                gameObject.SetActive(false);
                return;
            }
        }
        finalLevel.SetActive(true);
    }
}