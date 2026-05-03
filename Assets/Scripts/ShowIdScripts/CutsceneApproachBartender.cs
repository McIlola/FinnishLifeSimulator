using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneApproachBartender : CutsceneBase
{
    [SerializeField] private float targetSize;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float bobbingAmount;
    [SerializeField] private float bobbingSpeed;
    public AudioSource audioSource;
    public AudioClip stepsAudio;
    private Camera cam;

    public override void Execute()
    {
        cam = cutsceneHandler.cam;
        cutsceneHandler.SetPlayerControl(false);
        StartCoroutine(ZoomCamera());
    }

    private IEnumerator ZoomCamera()
    {
        Vector3 originalPosition = cam.transform.position;
        Vector3 targetPosition = target.position + offset;
        float originalSize = cam.orthographicSize;
        float startTime = Time.time;
        float elapsedTime = 0;
        audioSource.PlayOneShot(stepsAudio, 1);
        
        while(elapsedTime < duration)
        {
            float t = Mathf.SmoothStep(0, 1, elapsedTime / duration);
            float bobOffset = Mathf.Sin(elapsedTime * bobbingSpeed) * bobbingAmount;
            cam.orthographicSize = Mathf.Lerp(originalSize, targetSize, t);
            cam.transform.position = Vector3.Lerp(originalPosition, targetPosition, t) + new Vector3(0, bobOffset, 0);
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        cam.orthographicSize = targetSize;
        cam.transform.position = targetPosition;
        cutsceneHandler.PlayNextElement();
    }
}
