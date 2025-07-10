using UnityEngine;

public class Cole : MonoBehaviour
{
    public int score = 1; // Pontuação do item

    // Variables para o movimento suave
    public float amplitude = 0.5f; // altura do movimento
    public float frequency = 1f; // velocidade do movimento

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        // Movimento suave de cima para baixo usando seno
        transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * frequency) * amplitude;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(score);
            }
            else
            {
                Debug.LogWarning("ScoreManager não encontrado!");
            }

            Destroy(gameObject);
        }
    }
}
