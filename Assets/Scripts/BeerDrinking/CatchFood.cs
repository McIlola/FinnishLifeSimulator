using UnityEngine;

public class Catcher : MonoBehaviour
{
    public AudioSource drinkSound;
    public AudioSource pukeSound;
    void OnCollisionEnter2D(Collision2D collision)
    {
        FallingItem item = collision.gameObject.GetComponent<FallingItem>();

        if (item != null)
        {
            if (item.scoreValue > 0)
            {
                drinkSound.Play();            
            }
            else
            {
                pukeSound.Play();
            }
            SisuManager.Instance.AddCurrency(item.scoreValue);
            Destroy(collision.gameObject);
        }
    }
}