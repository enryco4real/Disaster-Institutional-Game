using UnityEngine;
using System.Collections;

public class Mira : MonoBehaviour
{
    public Transform player;   
    public float speed = 5f;   
    public Color blinkColor = Color.white; // Cor de piscar
    private Color originalColor;  // Cor original da mira
    private SpriteRenderer spriteRenderer; // Componente SpriteRenderer para alterar a cor
    private Vector3 originalScale; // Escala original da mira

    private void Start()
    {
        // Se player não estiver atribuído, tenta achar o objeto com a tag "Player"
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Obtém o componente SpriteRenderer da mira
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Armazena a cor original da mira
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }

        // Armazena a escala original da mira
        originalScale = transform.localScale;
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
        // Verifica se o objeto com o qual a mira colidiu é o player
        if (other.CompareTag("Player"))
        {
            // Chama a função de piscar antes de destruir o player
            StartCoroutine(BlinkAndDestroy(other.gameObject));
        }
    }

    // Coroutine para piscar a mira antes de destruir o player
    private IEnumerator BlinkAndDestroy(GameObject playerObject)
    {
        float blinkDuration = 2f; 
        float timeElapsed = 0f;
        float scaleMagnitude = 1.2f; 
        Vector3 maxScale = originalScale * scaleMagnitude; 

       
        transform.position = player.position;

        
        while (timeElapsed < blinkDuration)
        {
            
            spriteRenderer.color = (timeElapsed % 0.5f < 0.25f) ? blinkColor : originalColor;

            
            float scaleFactor = Mathf.PingPong(timeElapsed * 2f, 1f); 
            transform.localScale = Vector3.Lerp(originalScale, maxScale, scaleFactor);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        
        Destroy(playerObject);
        PlayerStatus.playerDestroyed = true;
        FindObjectOfType<Restart>().TriggerGameOver();
        GameController.instance.gameOver();
    }
}
