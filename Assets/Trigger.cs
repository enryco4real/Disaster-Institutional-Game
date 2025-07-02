using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject fireball;
    public float velocidadeFireball = 5f;

    void OnTriggerEnter2D(Collider2D outroObjeto)
    {
        if (outroObjeto.CompareTag("Player"))
        {
            AtivarMovimentoFireball();
        }
    }

    void AtivarMovimentoFireball()
    {
        if (fireball != null)
        {
            Rigidbody2D rbFireball = fireball.GetComponent<Rigidbody2D>();
            if (rbFireball != null)
            {
                rbFireball.velocity = new Vector2(velocidadeFireball, 0);
            }
        }
    }
}