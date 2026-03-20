using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = "Sisu: " + CurrencyManager.Instance.currency.ToString();
    }
}