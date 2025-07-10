using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerF2 : MonoBehaviour
{
    public static GameControllerF2 instance;

    [Header("Contador Inicial")]
    public float startDelay = 5f;
    public Text timerText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(StartGameWithDelay());
    }

    private void Update()
    {
        
    }

    IEnumerator StartGameWithDelay()
    {
        Time.timeScale = 0f;
        float countdown = startDelay;

        while (countdown > 0)
        {
            timerText.text = "PRESS SPACE IN: " + Mathf.Ceil(countdown).ToString();
            yield return new WaitForSecondsRealtime(1f); 
            countdown -= 1f;
        }

        timerText.text = ""; 
        Time.timeScale = 1f; 
    }
}