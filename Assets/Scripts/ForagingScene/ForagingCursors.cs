using UnityEngine;

public class ForagingCursors : MonoBehaviour
{
    public static ForagingCursors Instance { get; private set; }
    [SerializeField] private Texture2D cursorSpriteNormal;
    [SerializeField] private Texture2D cursorSpritePicker;
    [SerializeField] private Texture2D cursorSpriteFlyswatter;
    [SerializeField] private Vector2 cursorPosition = Vector2.zero;

    private void Awake()
    {
        Instance = this;
    }
    public void SetToMode(TargetSpriteCursor targetSpriteCursor)
    {
        switch (targetSpriteCursor)
        {
            case TargetSpriteCursor.Default:
                Cursor.SetCursor(cursorSpriteNormal, cursorPosition, CursorMode.Auto);
                break;

            case TargetSpriteCursor.Picker:
                Cursor.SetCursor(cursorSpritePicker, cursorPosition, CursorMode.Auto);
                break;

            case TargetSpriteCursor.Flyswatter:
                Cursor.SetCursor(cursorSpriteFlyswatter, cursorPosition, CursorMode.Auto);
                break;

            default:
                Cursor.SetCursor(cursorSpriteNormal, cursorPosition, CursorMode.Auto);
                break;
        }
    }

    public enum TargetSpriteCursor
    {
        Default,
        Picker,
        Flyswatter
    }
}
