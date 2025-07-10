using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TypewriterEffect : MonoBehaviour
{
    public Text uiText;
    [TextArea] public string fullText;
    public float typingSpeed = 0.05f;
    public GameObject pressEnterObject;
    public GameObject Pontuacao;
    public GameObject Premio;

    public float blinkInterval = 0.5f;
    public bool IscreditOver = false;

    private void Start()
    {
        IscreditOver = false;
        if (pressEnterObject != null)
            pressEnterObject.SetActive(false);
            Pontuacao.SetActive(false);
            Premio.SetActive(false);
            

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
        {
            pressEnterObject.SetActive(true);
            Pontuacao.SetActive(true);
            Premio.SetActive(true);
            StartCoroutine(BlinkPressEnter());
        }
    }

    IEnumerator BlinkPressEnter()
    {
        Text blinkText = pressEnterObject.GetComponent<Text>();
        while (true)
        {
            IscreditOver = true;       
            blinkText.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
            blinkText.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
