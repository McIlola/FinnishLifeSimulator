using UnityEngine;

public class MoveTo : MonoBehaviour {
    public float speed = 10f;
    public float horizontalVariation = 0.5f;

    private Vector2 direction;

    void Start() {
        float randomX = Random.Range(-horizontalVariation, horizontalVariation);
        direction = new Vector2(randomX, 1f).normalized;
    }

    void Update() {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }
}