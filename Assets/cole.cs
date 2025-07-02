using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cole : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float floatHeight = 0.25f;
    private Vector3 startPos;
    public int score;
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
{
        if (collision.CompareTag("Player") && gameObject.CompareTag("itens"))
        {
            Destroy(gameObject); 
            GameController.instance.totalscore += score;
            GameController.instance.UpdateScoreText();
    }
}

}
