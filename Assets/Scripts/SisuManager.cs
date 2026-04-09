using UnityEngine;

public class SisuManager : MonoBehaviour
{
    public static SisuManager Instance;

    public int currency = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
    }

    public void SpendCurrency(int amount)
    {
        currency -= amount;
    }
}