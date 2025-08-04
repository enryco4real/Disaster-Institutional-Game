using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text scoreText;  
    public int totalscore;  
    public int finalscore;  
    public GameObject gameoverPanel; 

    void Awake()
    {
        // Garante que há apenas uma instância do GameController
        if (instance == null)
        {
            instance = this;
        }
    }
void Start()
{
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;

    // Zera o score da rodada
    if (ScoreManager.instance != null)
    {
        // Atribui a referência atual da cena ao ScoreManager
        ScoreManager.instance.scoreUIText = scoreText;

        // Reseta o score para esta rodada
        ScoreManager.instance.ResetScore();
    }

    UpdateScoreText();

    if (gameoverPanel != null)
        gameoverPanel.SetActive(false);
}


    // Atualiza a exibição da pontuação e acumula o finalscore
    public void UpdateScoreText()
    {
        // Atualiza a UI com o valor de totalscore
        scoreText.text = totalscore.ToString();

        // Acumula o finalscore com o valor do totalscore
        finalscore += totalscore;  // Soma os pontos atuais de totalscore ao finalscore
    }

    // Função que é chamada quando o jogador perde (Game Over)
    public void gameOver()
    {
        // Exibe o painel de Game Over
        if (gameoverPanel != null)
        {
            gameoverPanel.SetActive(true);
        }

        // Não salvamos a pontuação nesse caso
        Debug.Log("Game Over! Pontuação perdida.");
    }

    // Função que salva a pontuação antes de trocar a cena
    public void SaveScore()
{
    if (finalscore >= 0)
{
    Debug.Log("Pontuação atual em tempo real: " + finalscore); // << Linha adicionada

    // Salva a pontuação final no PlayerPrefs
    PlayerPrefs.SetInt("scoretokeep", finalscore);
    PlayerPrefs.Save();  // Garante que os dados sejam salvos imediatamente
    Debug.Log("Pontuação salva: " + finalscore);
}

    else
    {
        // Se o valor for negativo, exibe um erro
        Debug.LogError("Tentativa de salvar uma pontuação inválida!");
        }
    }
}