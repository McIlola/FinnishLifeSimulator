using TMPro;
using UnityEngine;

public class SisuUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = SisuManager.Instance.currency.ToString();
    }
}