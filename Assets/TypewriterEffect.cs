using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public Text uiText;                     
    [TextArea] public string fullText;     
    public float typingSpeed = 0.05f;
    public GameObject pressEnterObject;    
    public float blinkInterval = 0.5f;     

    private void Start()
    {
        if (pressEnterObject != null)
            pressEnterObject.SetActive(false); 

        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        uiText.text = "";
        foreach (char letter in fullText)
        {
            uiText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        
        if (pressEnterObject != null)
            StartCoroutine(BlinkPressEnter());
    }

    IEnumerator BlinkPressEnter()
    {
        pressEnterObject.SetActive(true);

        Text blinkText = pressEnterObject.GetComponent<Text>();
        while (true)
        {
            blinkText.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
            blinkText.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
