using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [Header("Basic functionality")]
    [SerializeField] private Texture2D cursorSpriteNormal;
    [SerializeField] private Vector2 cursorPosition = Vector2.zero;
    private Vector2 cursorHotspot;

    void Start()
    {
        Cursor.SetCursor(cursorSpriteNormal, cursorPosition, CursorMode.Auto);
    }

}
