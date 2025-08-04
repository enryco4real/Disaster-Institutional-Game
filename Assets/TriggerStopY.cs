using UnityEngine;

public class StopYMovementOnTrigger : MonoBehaviour
{
    public float freezeDuration = 1f; // quanto tempo ele fica sem mover no Y

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Zera o movimento no eixo Y
                rb.velocity = new Vector2(rb.velocity.x, 0f);

                // Opcional: Desativa temporariamente a gravidade
                StartCoroutine(FreezeY(rb));
            }
        }
    }

    private System.Collections.IEnumerator FreezeY(Rigidbody2D rb)
    {
        float originalGravity = rb.gravityScale;

        rb.gravityScale = 0f;

        yield return new WaitForSeconds(freezeDuration);

        rb.gravityScale = originalGravity;
    }
}
