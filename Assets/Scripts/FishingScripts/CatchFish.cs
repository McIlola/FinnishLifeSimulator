using UnityEngine;
using UnityEngine.InputSystem;

public class CatchFish : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            animator.SetTrigger("Catch");
        }
    }
}
