using UnityEngine;

public class DisablePlayerColliderTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BoxCollider2D playerCollider = other.GetComponent<BoxCollider2D>();
            if (playerCollider != null)
            {
                playerCollider.enabled = false;
                Debug.Log("BoxCollider2D do Player foi desativado.");
            }
            else
            {
                Debug.LogWarning("O objeto Player não tem um BoxCollider2D.");
            }
        }
    }
}
