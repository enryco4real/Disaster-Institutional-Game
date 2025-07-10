using UnityEngine;

public class Lightning : MonoBehaviour
{
    public float speed = -5f;
    public float destroyAfterSeconds = 5f;

    private bool isMoving = false;

    void Update()
    {
        if (isMoving)
        {
            Movi();
            CheckPlayerPresence();
        }
    }

    void Movi()
    {

        transform.position -= Vector3.left * speed * Time.deltaTime;
    }

    public void Activate()
    {
        isMoving = true;
        Destroy(gameObject, destroyAfterSeconds);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isMoving && other.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }
            void CheckPlayerPresence()
    {
        GameObject player = GameObject.FindWithTag("lightining");

        
        if (player == null)
        {
            gameObject.SetActive(false);
        }
    }

}
