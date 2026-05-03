using UnityEngine;

public class HandInsideBoundary : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boundary;
    [SerializeField] private BoxCollider2D hand;
    [SerializeField] private SpriteRenderer boundaryColor;

    [SerializeField] private Color insideColor = Color.green;
    [SerializeField] private Color outsideColor = Color.red;

    void Update()
    {
        if (IsFullyInside())
        {
            boundaryColor.color = insideColor;
        }
        else
        {
            boundaryColor.color = outsideColor;
        }
    }

    public bool IsFullyInside()
    {
        Bounds boundaryBounds = boundary.bounds;
        Bounds handBounds = hand.bounds;

        Vector3 min = handBounds.min;
        Vector3 max = handBounds.max;
        Vector3 topLeft = new Vector3(min.x, max.y);
        Vector3 topRight = new Vector3(max.x, max.y);
        Vector3 bottomLeft = new Vector3(min.x, min.y);
        Vector3 bottomRight = new Vector3(max.x, min.y);

        return boundaryBounds.Contains(topLeft) &&
               boundaryBounds.Contains(topRight) &&
               boundaryBounds.Contains(bottomLeft) &&
               boundaryBounds.Contains(bottomRight);
    }
}