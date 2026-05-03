using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public Collider2D mouthCollider;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);

        ClampToScreen();
    }

    void ClampToScreen()
    {
        Bounds bounds = mouthCollider.bounds;

        float leftEdge = bounds.min.x;
        float rightEdge = bounds.max.x;

        float screenLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        Vector3 pos = transform.position;

        if (leftEdge < screenLeft)
        {
            pos.x += screenLeft - leftEdge;
        }
        else if (rightEdge > screenRight)
        {
            pos.x -= rightEdge - screenRight;
        }

        transform.position = pos;
    }
}