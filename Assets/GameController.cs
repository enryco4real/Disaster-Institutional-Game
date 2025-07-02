using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text scoreText;
    public int totalscore;

    public GameObject gameover;
    

    void Start()
    {
         
        
        instance = this;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalscore.ToString();
    }

    public void gameOver()
    {
        gameover.SetActive(true);
    }

    
}
