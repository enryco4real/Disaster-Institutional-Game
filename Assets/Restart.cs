using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public GameObject restartText;
    public bool isGameOver = false;
    public float fadeDuration = 1.5f;
    public Image fadeImage;

    void Start()
    {
        Time.timeScale = 1f;
        if (restartText != null) restartText.SetActive(false);
        if (fadeImage != null) fadeImage.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Return))
        {
            PlayerStatus.playerDestroyed = false;
            FadeRestart();
        }
    }

    public void TriggerGameOver()
    {
        isGameOver = true;
        if (restartText != null) restartText.SetActive(true);
        Time.timeScale = 0f;
    }

    public void FadeRestart()
    {
        StartCoroutine(FadeAndLoadScene("Menu"));
    }

    private IEnumerator FadeAndLoadScene(string sceneName)
    {
        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);
            float timer = 0f;

            while (timer < fadeDuration)
            {
                timer += Time.unscaledDeltaTime;
                float alpha = Mathf.Clamp01(timer / fadeDuration);
                fadeImage.color = new Color(0, 0, 0, alpha);
                yield return null;
            }
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
