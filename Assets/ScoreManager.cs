using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int totalScore = 0;
    private const string scoreKey = "scoreToKeep";

    [Header("UI da fase (atual)")]
    public Text scoreUIText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Persiste entre cenas
        }
        else
        {
            Destroy(gameObject);  // Evita duplicatas
        }
    }

    public void AddScore(int points)
    {
        totalScore += points;
        Debug.Log("Pontuação atual: " + totalScore);

        // Atualiza a UI da fase, se houver
        if (scoreUIText != null)
        {
            scoreUIText.text = totalScore.ToString();
        }
    }

    public int GetScore()
    {
        return totalScore;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt(scoreKey, totalScore);
        PlayerPrefs.Save();
        Debug.Log("Pontuação salva: " + totalScore);
    }
    public void ResetScore()
{
    totalScore = 0;

    // Atualiza a UI
    if (scoreUIText != null)
    {
        scoreUIText.text = "0";
    }

    // Limpa o valor salvo no disco
    PlayerPrefs.DeleteKey("scoreToKeep");

    Debug.Log("Pontuação resetada e salva removida.");
}


}
