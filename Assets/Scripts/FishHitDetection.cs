using UnityEngine;
using UnityEngine.InputSystem;

public class FishHitDetection : MonoBehaviour
{
    public RectTransform indicator;
    public RectTransform targetZone;
    public RectTransform bar;
    public void RandomizeTargetZone()
    {
        float randomY = Random.Range(
            -bar.rect.height / 2,
            bar.rect.height / 2
        );

        targetZone.localPosition = new Vector3(0, randomY, 0);
    }
    public int rewardAmount = 10;
    public GameObject fishPrefab;
    public Transform fishContainer;
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            CheckHit();
        }
    }
    void SpawnFish()
    {
        RectTransform containerRect = fishContainer.GetComponent<RectTransform>();
        GameObject fish = Instantiate(fishPrefab, fishContainer);

        float width = containerRect.rect.width;
        float height = containerRect.rect.height;

        float randomX = Random.Range(-width / 2, width / 2);
        float randomY = Random.Range(-height / 2, height / 2);

        fish.transform.localPosition = new Vector3(randomX, randomY, 0);
        Debug.Log("Spawned fish!");
        Destroy(fish, 10f);
    }
    void CheckHit()
    {
        float indicatorY = indicator.localPosition.y;

        float minY = targetZone.localPosition.y - targetZone.rect.height / 2;
        float maxY = targetZone.localPosition.y + targetZone.rect.height / 2;

        if (indicatorY >= minY && indicatorY <= maxY)
        {
            Debug.Log("Caught fish!");
            SisuManager.Instance.AddCurrency(rewardAmount);
            SpawnFish();
        }
        else
        {
            Debug.Log("Missed:(");
        }
        RandomizeTargetZone();
    }
}
