using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject normalGoodPrefab;
    public GameObject normalBadPrefab;
    public GameObject veryGoodPrefab;
    public GameObject veryBadPrefab;


    public float spawnRate = 1f;
    public float spawnXRange = 8f;
    public float spawnY = 6f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnRate);
    }

    void Spawn()
    {
        float x = Random.Range(-spawnXRange, spawnXRange);
        Vector2 pos = new Vector2(x, spawnY);

        float roll = Random.value;

        GameObject prefab;

        if (roll < 0.6f)
            prefab = normalGoodPrefab;
        else if (roll < 0.8f)
            prefab = normalBadPrefab;
        else if (roll < 0.95f)
            prefab = veryGoodPrefab;
        else
            prefab = veryBadPrefab;

        Instantiate(prefab, pos, Quaternion.identity);
    }
}