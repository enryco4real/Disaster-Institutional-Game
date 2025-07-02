using UnityEngine;

public class Mira : MonoBehaviour
{
    public Transform player;   
    public float speed = 5f;   

    private void Start()
    {
        
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;  
            transform.position += direction * speed * Time.deltaTime;  
        }
    }

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
