using UnityEngine;

public class SisuStore : MonoBehaviour
{
    void Start()
    {
        SisuManager.Instance.SaveSceneStartCurrency();
    }

}
