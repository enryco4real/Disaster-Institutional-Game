using UnityEngine;

public class triggercam : MonoBehaviour
{
    public CameraMoveRight cameraScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraScript.StopMovement();
        }
    }
}
