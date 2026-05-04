using UnityEngine;

public class FinalSisuCount : MonoBehaviour
{
    private int finalScore;
    public AudioSource epicVictory;
    public AudioSource moderateVictory;
    public AudioSource bigFail;
    public GameObject badEnd;
    public GameObject okayEnd;
    public GameObject bestEnd;

    void Start()
    {
        finalScore = SisuManager.Instance.currency;

        if (finalScore < 0)
        {
            bigFail.Play(0);
            badEnd.SetActive(true);
        }
        if (finalScore >= 0 && finalScore < 200)
        {
            moderateVictory.Play(0);
            okayEnd.SetActive(true);
        }
        if (finalScore > 200)
        {
            epicVictory.Play(0);
            bestEnd.SetActive(true);
        }
    }

}
