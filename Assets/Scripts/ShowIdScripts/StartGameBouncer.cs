using UnityEngine;

public class StartGameBouncer : MonoBehaviour
{    
    [SerializeField] private GameObject startGameScreen;
    public void Begin()
    {
        startGameScreen.SetActive(false);
    }

}
