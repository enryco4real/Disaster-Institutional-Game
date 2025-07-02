using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    public Text uiText;
    public Color color1 = Color.white;
    public Color color2 = Color.red;
    public float blinkSpeed = 1f;

    private Coroutine blinkCoroutine;

    void Awake()
    {
        if (uiText == null)
            uiText = GetComponent<Text>();
    }

    void OnEnable()
    {
        blinkCoroutine = StartCoroutine(Blink());
    }

    void OnDisable()
    {
        if (blinkCoroutine != null)
            StopCoroutine(blinkCoroutine);
    }

    System.Collections.IEnumerator Blink()
    {
        while (true)
        {
            float t = 0f;
            while (t < 1f)
            {
                uiText.color = Color.Lerp(color1, color2, t);
                t += Time.unscaledDeltaTime * blinkSpeed;
                yield return null;
            }

            t = 0f;
            while (t < 1f)
            {
                uiText.color = Color.Lerp(color2, color1, t);
                t += Time.unscaledDeltaTime * blinkSpeed;
                yield return null;
            }
        }
    }
}
