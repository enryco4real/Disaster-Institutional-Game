using UnityEngine;

public class CameraMoveRight : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float acceleration = 0.2f;
    private float currentSpeed;
    public float maxSpeed = 10f;

    private bool stopMoving = false;
    public float deceleration = 5f; 

    void Start()
    {
        currentSpeed = baseSpeed;
    }

    void Update()
    {
        if (!PlayerStatus.playerDestroyed)
        {
            if (!stopMoving)
            {
                currentSpeed += acceleration * Time.deltaTime;
                currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
            }
            else
            {

                currentSpeed -= deceleration * Time.deltaTime;
                if (currentSpeed < 0)
                    currentSpeed = 0;
            }

            transform.position += Vector3.right * currentSpeed * Time.deltaTime;

        }
    }
    public void StopMovement()
    {
        stopMoving = true;
    }
}
