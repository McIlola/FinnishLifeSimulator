using UnityEngine;
using UnityEngine.UI;

public class BreathMeterTracker : MonoBehaviour
{
    [SerializeField] private Slider breathLevel;
    public bool normalBreathing;

    [SerializeField] private float fillSpeed = 0.2f;
    [SerializeField] private float drainSpeed = 0.2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            breathLevel.value += fillSpeed*Time.deltaTime;
        }
        else
        {
            breathLevel.value -= drainSpeed*Time.deltaTime;
        }

        if (breathLevel.value > 0.20 && breathLevel.value < 0.8)
        {
            normalBreathing = true;
        }
        else
        {
            normalBreathing = false;
        }

        breathLevel.value = Mathf.Clamp(breathLevel.value, breathLevel.minValue, breathLevel.maxValue);
    }
}