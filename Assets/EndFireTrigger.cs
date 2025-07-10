using UnityEngine;

public class EndFireTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject[] firewalls = GameObject.FindGameObjectsWithTag("firewall");

            foreach (GameObject fw in firewalls)
            {
                Destroy(fw);
            }
        }
    }
}
