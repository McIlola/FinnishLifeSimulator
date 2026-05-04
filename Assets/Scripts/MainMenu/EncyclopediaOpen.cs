using UnityEngine;

public class EncyclopediaOpen : MonoBehaviour
{
    private Collider2D objectCollider;
    public SpriteRenderer[] outlineRenderer;
    [SerializeField] private GameObject encyclopediaView;
    [SerializeField] private string[] requiredTrivia;

    bool IsUnlocked()
    {
        foreach (string level in requiredTrivia)
        {
            if (!CompletedLevels.completedLevels.Contains(level))
                return false;
        }
        return true;
    }

    void Start()
    {
        objectCollider = GetComponent<Collider2D>();

        outlineRenderer = new SpriteRenderer[transform.childCount];
        for (int i = 0; i < outlineRenderer.Length; i++)
        {
            outlineRenderer[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
        }

        if (!IsUnlocked())
        {
            foreach (SpriteRenderer outline in outlineRenderer)
            {
                outline.color = Color.gray;
            }

            objectCollider.enabled = false;
        }
    }

    void Update()
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
                encyclopediaView.SetActive(true);
            }
        }
        else
        {
            foreach(SpriteRenderer outline in outlineRenderer)
            {
                outline.color = Color.black;
            }
        }
    }
}
