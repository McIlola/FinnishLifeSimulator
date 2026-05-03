using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneMoveObject : CutsceneBase
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Transform targetObject;
    [SerializeField] private StartGameBouncer startGameScreen;
    public AudioSource audioSource;
    public AudioClip moveHandAudio;

    public override void Execute()
    {
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        Vector3 originalPosition = targetObject.position;
        float startTime = Time.time;
        float elapsedTime = 0;
        audioSource.PlayOneShot(moveHandAudio, 1);
        
        while(elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            targetObject.transform.position = Vector3.Lerp(originalPosition, targetPosition, t);
            elapsedTime = Time.time - startTime;
            yield return null;
        }

        targetObject.position = targetPosition;
        startGameScreen.Begin();
        cutsceneHandler.PlayNextElement();
    }
}