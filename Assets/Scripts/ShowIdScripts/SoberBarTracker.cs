using UnityEngine;
using UnityEngine.UI;

public class SoberBarTracker : MonoBehaviour
{
    [SerializeField] private Slider soberLevel;
    [SerializeField] private HandInsideBoundary handChecker;
    [SerializeField] private BreathMeterTracker breathThreshold;
    [SerializeField] private GameObject breathMeter;
    

    [SerializeField] private float fillSpeed = 0.05f;
    [SerializeField] private float drainSpeed = 0.05f;
    public float rewardInterval = 0.5f;
    private float nextRewardTime;
    public int rewardAmount = 1;
    void Begin()
    {
        nextRewardTime = Time.time + rewardInterval;
    }

    void ScheduleNextReward()
    {
        nextRewardTime = Time.time + rewardInterval;
    }

    void Update()
    {
        if (handChecker.IsFullyInside())
        {
            if (breathMeter.activeSelf)
            {
                if (breathThreshold.normalBreathing)
                {
                    soberLevel.value += fillSpeed * Time.deltaTime;
                }
                else
                {
                    soberLevel.value -= drainSpeed * Time.deltaTime;
                }
            }
            else
            {
                soberLevel.value += fillSpeed * Time.deltaTime;
            }
        }
        else
        {
            soberLevel.value -= drainSpeed * Time.deltaTime;
        }

        soberLevel.value = Mathf.Clamp(soberLevel.value, soberLevel.minValue, soberLevel.maxValue);

        if(Time.time > nextRewardTime)
        {
            if (soberLevel.value >= 0.95)
            {
                GiveSisu();
            }

            if (soberLevel.value >= 0.5)
            {
                GiveSisu();
            }
            else
            {
                LoseSisu();
            }

            ScheduleNextReward();
        }
    }

    void GiveSisu()
    {
        SisuManager.Instance.AddCurrency(rewardAmount);
    }

    void LoseSisu()
    {
        SisuManager.Instance.AddCurrency(-rewardAmount);
    }
}