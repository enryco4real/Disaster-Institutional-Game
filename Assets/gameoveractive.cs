using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameoveractive : MonoBehaviour
{
    public GameObject GameOver;
    public bool isGameOver = false;
    void Start()
    {
        isGameOver = false;
        if (GameOver != null)
        {
            SpriteRenderer sr = GameOver.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.enabled = false;
            }
        }
    }
    public void TriggerGameOver()
    {
        isGameOver = true;

        if (GameOver != null)
        {
            SpriteRenderer sr = GameOver.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.enabled = true;
            }
        }

        Time.timeScale = 0f;
    }
}



