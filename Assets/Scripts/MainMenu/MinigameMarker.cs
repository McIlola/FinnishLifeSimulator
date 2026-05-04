using UnityEngine;

public class MinigameMarker : MonoBehaviour
{
    public string levelID;
    private Collider2D objectCollider;
    public SpriteRenderer[] outlineRenderer;
    [SerializeField] private GameObject minigamePopUp;
    void Start()
    {
        if (CompletedLevels.completedLevels.Contains(levelID))
        {
            gameObject.SetActive(false);
        }
        objectCollider = GetComponent<Collider2D>();
        outlineRenderer = new SpriteRenderer[transform.childCount];

        for (int i = 0; i < outlineRenderer.Length; i++)
        {
            outlineRenderer[i] = transform.GetChild(i).GetComponent<SpriteRenderer>();
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
                minigamePopUp.SetActive(true);
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
