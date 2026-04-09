using TMPro;
using UnityEngine;

public class SisuUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = "Sisu: " + SisuManager.Instance.currency.ToString();
    }
}