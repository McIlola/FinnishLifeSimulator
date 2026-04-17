using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using Unity.Cinemachine;

public class CutsceneHandler : MonoBehaviour
{
    public Camera cam;
    public CinemachineCamera vCam;
    [SerializeField] private HandMovement playerMovement;

    private CutsceneBase[] cutsceneElements;
    private int index = -1;

    public void Start()
    {
        cutsceneElements = GetComponents<CutsceneBase>();
    }

    public void SetPlayerControl(bool enabled)
    {
        if (playerMovement != null)
            playerMovement.movementEnabled = enabled;
    }

    private void PlayCurrentElement()
    {
        if(index >= 0 && index < cutsceneElements.Length)
            cutsceneElements[index].Execute();
    }

    public void PlayNextElement()
    {
        index++;
        PlayCurrentElement();
    }
}
