using UnityEngine;

public class SwattableMosquito : MonoBehaviour
{
    [SerializeField] private ForagingCursors.TargetSpriteCursor targetSpriteCursor;
    private Collider2D objectCollider;
    private Vector3 currentSize;

    [Header ("Growth")]
    public float maxSize = 2f;
    public float growth = 0.0001f;

    [Header ("Random movement")]
    public float damping = 0.95f;
    public float minInterval = 1f;
    public float maxInterval = 1.5f;
    public float minForce = 20f;
    public float maxForce = 50f;
    private Vector2 velocity;
    private Vector2 currentForce;
    private float nextRMTime;

    public float cameraSpeed;
    public bool gamePaused = false;



    void Start()
    {
        objectCollider = GetComponent<Collider2D>();
        currentSize = transform.localScale;
        ScheduleNextRM();
    }

    void ScheduleNextRM()
    {
        nextRMTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    void ApplyRandomMovement()
    {
        Vector2 direction = Random.insideUnitCircle.normalized;
        float strength = Random.Range(minForce, maxForce);

        currentForce = direction * strength;

        ScheduleNextRM();
    }

    void Update()
    {
        if (gamePaused) return;

        if (Time.time >= nextRMTime)
        {
            ApplyRandomMovement();
            ScheduleNextRM();
        }

        velocity += currentForce * Time.deltaTime;
        velocity *= damping;

        transform.position += (Vector3)(velocity * Time.deltaTime);
        transform.position += Vector3.right * cameraSpeed * Time.deltaTime;
        
        KeepInsideScreen();

        GrowMosquito();
    }

    void KeepInsideScreen()
    {
        Camera cam = Camera.main;


        Vector3 min = cam.ScreenToWorldPoint(new Vector2(0, 0));
        Vector3 max = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Vector3 pos = transform.position;

        if (pos.x < min.x)
        {
            pos.x = min.x;
            velocity.x *= -1;
        }
        else if (pos.x > max.x)
        {
            pos.x = max.x;
            velocity.x *= -1;
        }

        // Bottom / Top
        if (pos.y < min.y)
        {
            pos.y = min.y;
            velocity.y *= -1;
        }
        else if (pos.y > max.y)
        {
            pos.y = max.y;
            velocity.y *= -1;
        }

        transform.position = pos;
    }

    void GrowMosquito()
    {
        if (currentSize.x < maxSize)
        {
            currentSize += new Vector3(growth, growth, 0f);

            transform.localScale = currentSize;
        }
    }

    void OnMouseEnter()
    {
        ForagingCursors.Instance.SetToMode(targetSpriteCursor);
    }

    void OnMouseExit()
    {
        ForagingCursors.Instance.SetToMode(ForagingCursors.TargetSpriteCursor.Default);
    }

    void OnMouseDown()
    {
        ForagingCursors.Instance.SetToMode(ForagingCursors.TargetSpriteCursor.Default);
        Destroy(this.gameObject);
    }
}
