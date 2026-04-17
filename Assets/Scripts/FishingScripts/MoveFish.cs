using UnityEngine;

public class MoveTo : MonoBehaviour {
    public float speed = 10f;
    private Vector3 targetPosition;
    void Start() {
        SetNewTarget();
    }

    void Update() {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            speed * Time.deltaTime
        );

        
    }

    void SetNewTarget() {
        float randomX = Random.Range(-50f, 50f);
        targetPosition = new Vector3(randomX, 0f, 0f);
    }
}