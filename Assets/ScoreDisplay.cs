using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;
    private const string scoreKey = "scoreToKeep";

    void Start()
    {
        int savedScore = PlayerPrefs.GetInt(scoreKey, 0);
        scoreText.text = "Pontuacao final: " + savedScore.ToString();
        Debug.Log("Pontuação carregada: " + savedScore);
    }
}
