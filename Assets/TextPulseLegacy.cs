using UnityEngine;
using UnityEngine.UI;

public class TextPulseLegacy : MonoBehaviour
{
    public Text texto;
    public int minSize = 20;
    public int maxSize = 40;
    public float speed = 8f;

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1);
        int size = Mathf.RoundToInt(Mathf.Lerp(minSize, maxSize, t));
        texto.fontSize = size;
    }
}
