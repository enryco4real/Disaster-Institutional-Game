using UnityEngine;

public class TriggerLighting : MonoBehaviour
{
    public GameObject lightning;
    public float velocidadelightning = 5f;

    void OnTriggerEnter2D(Collider2D outroObjeto)
    {
        if (outroObjeto.CompareTag("Player"))
        {
            AtivarMovimentoLighting();
        }
    }

    void AtivarMovimentoLighting()
    {
        if (lightning != null)
        {
            Rigidbody2D rblightning = lightning.GetComponent<Rigidbody2D>();
            if (rblightning != null)
            {
                rblightning.velocity = new Vector2(velocidadelightning, 0);
            }
        }
    }
}