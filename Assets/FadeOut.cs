using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeOutController : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.5f;

    public void FadeAndLoadScene(string sceneName)
    {
        
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float timer = 0f;

        if (fadeImage != null)
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.color = new Color(0, 0, 0, 0f);
            Canvas.ForceUpdateCanvases(); 
        }
        else
        {
           
            SceneManager.LoadScene(sceneName);
            yield break;
        }

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 1f);
        yield return new WaitForEndOfFrame(); 
        SceneManager.LoadScene(sceneName);
    }
}
