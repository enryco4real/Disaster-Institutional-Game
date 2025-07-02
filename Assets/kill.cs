using UnityEngine;
using UnityEngine.UI;

public class Kill : MonoBehaviour

{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            PlayerStatus.playerDestroyed = true;
            FindObjectOfType<Restart>().TriggerGameOver();
            GameController.instance.gameOver(); 


        }
    }

    
}
