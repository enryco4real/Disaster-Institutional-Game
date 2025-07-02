using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public FadeController fadeController;
    public string nextSceneName = "About1";
    public float delayBeforeFade = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          
            SpriteRenderer playerRenderer = other.GetComponent<SpriteRenderer>();
            if (playerRenderer != null)
                playerRenderer.enabled = false;

            
            Invoke(nameof(StartFade), delayBeforeFade);
        }
    }

    private void StartFade()
    {
        fadeController.StartFadeOut(nextSceneName);
    }
}
