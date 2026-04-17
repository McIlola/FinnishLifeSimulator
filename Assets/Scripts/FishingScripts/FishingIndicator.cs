using UnityEngine;

public class FishingIndicator : MonoBehaviour
{
    public RectTransform bar;
    public float speed = 2f;

    private float t = 0f;

    void Update()
    {
        t += Time.deltaTime * speed;
        float pingPong = Mathf.PingPong(t, 1);

        float y = Mathf.Lerp(-bar.rect.height / 2, bar.rect.height / 2, pingPong);
        transform.localPosition = new Vector3(transform.localPosition.x, y, 0);
    }
}
