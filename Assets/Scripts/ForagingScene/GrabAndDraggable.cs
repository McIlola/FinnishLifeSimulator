using UnityEngine;

public class GrabAndDraggable : MonoBehaviour
{
    public SpriteRenderer[] outlineRenderer;
    private Rigidbody2D rb;
    [SerializeField] private ForagingCursors.TargetSpriteCursor targetSpriteCursor;
    bool isDragging;
    private Collider2D objectCollider;
    public int rewardAmount = 5;

    void Start()
    {
        outlineRenderer = new SpriteRenderer[transform.childCount];
        for (int i = 0; i < outlineRenderer.Length; i++)
        {
            outlineRenderer[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }

        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        objectCollider = GetComponent<Collider2D>();
        isDragging = false;
    }

    void Update()
    {
        DragAndDrop();
    }

    void DragAndDrop()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (objectCollider == Physics2D.OverlapPoint(mousePosition))
        {
            foreach(SpriteRenderer outline in outlineRenderer)
            {
                outline.color = Color.red;
            }
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
            }
        }
        else
        {
            foreach(SpriteRenderer outline in outlineRenderer)
            {
                outline.color = Color.black;
            }
        }

        if (isDragging)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            this.transform.position = mousePosition;
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cleanup")
        {
            ForagingCursors.Instance.SetToMode(ForagingCursors.TargetSpriteCursor.Default);
            Destroy(this.gameObject);
        }
        if (other.tag == "Bucket")
        {
            if (rb.bodyType == RigidbodyType2D.Dynamic)
            {
                ForagingCursors.Instance.SetToMode(ForagingCursors.TargetSpriteCursor.Default);
                Destroy(this.gameObject);
                SisuManager.Instance.AddCurrency(rewardAmount);
            }
        }
    }
}
