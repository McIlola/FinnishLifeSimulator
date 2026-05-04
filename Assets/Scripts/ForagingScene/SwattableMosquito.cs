using UnityEngine;

public class SwattableMosquito : MonoBehaviour
{
    public SpriteRenderer[] outlineRenderer;
    [SerializeField] private ForagingCursors.TargetSpriteCursor targetSpriteCursor;
    private Collider2D objectCollider;
    private Vector3 currentSize;
    public int rewardAmount = 5;

    [Header ("Growth")]
    public float maxSize = 10f;
    public float growth = 0.2f;

    [Header ("Random movement")]
    public float damping = 0.95f;
    public float minInterval = 0.5f;
    public float maxInterval = 1.0f;
    public float minForce = 10f;
    public float maxForce = 15f;
    private Vector2 velocity;
    private Vector2 currentForce;
    private float nextRMTime;
    public AudioClip swatSound;

    public float cameraSpeed;



    void Start()
    {
        outlineRenderer = new SpriteRenderer[transform.childCount];
        for (int i = 0; i < outlineRenderer.Length; i++)
        {
            outlineRenderer[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }

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


        Vector3 min = cam.ScreenToWorldPoint(new Vector2(50, 50));
        Vector3 max = cam.ScreenToWorldPoint(new Vector2(Screen.width-50, Screen.height-50));

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
            currentSize += new Vector3(growth, growth, 0f) * Time.deltaTime;
            transform.localScale = currentSize;
        }
    }

    void OnMouseEnter()
    {
        ForagingCursors.Instance.SetToMode(targetSpriteCursor);

        foreach(SpriteRenderer outline in outlineRenderer)
        {
            outline.color = Color.red;
        }
    }

    void OnMouseExit()
    {
        ForagingCursors.Instance.SetToMode(ForagingCursors.TargetSpriteCursor.Default);

        foreach(SpriteRenderer outline in outlineRenderer)
        {
            outline.color = Color.black;
        }
    }

    void OnMouseDown()
    {
        ForagingCursors.Instance.SetToMode(ForagingCursors.TargetSpriteCursor.Default);
        AudioSource.PlayClipAtPoint(swatSound, transform.position);
        SisuManager.Instance.AddCurrency(rewardAmount);
        Destroy(this.gameObject);
    }
}
