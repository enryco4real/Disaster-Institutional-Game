using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeRestart : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.5f;

    private bool canRestart = false;

    private void Start()
    {
        fadeImage.gameObject.SetActive(false);
    }

   
    public void EnableRestart()
    {
        canRestart = true;
    }

    private void Update()
    {
        if (canRestart && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            StartCoroutine(FadeAndRestartScene());
            canRestart = false; 
        }
    }

    private IEnumerator FadeAndRestartScene()
    {
        fadeImage.gameObject.SetActive(true);
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
