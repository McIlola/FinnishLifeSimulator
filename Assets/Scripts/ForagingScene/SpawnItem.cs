using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject foragingItem;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float spawnOffset;
    public float minInterval;
    public float maxInterval;
    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnOffset;
    }

    void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            Spawn();
            ScheduleNextSpawn();
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(foragingItem, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}