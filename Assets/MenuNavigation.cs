using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuNavigation : MonoBehaviour
{
    public Button[] buttons;  
    private int selectedIndex = 0;
    private Color normalTextColor;  
    private Coroutine blinkCoroutine;  
    void Start()
    {
        
        normalTextColor = buttons[0].GetComponentInChildren<Text>().color;
        SelectButton(selectedIndex);
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex = (selectedIndex - 1 + buttons.Length) % buttons.Length;
            SelectButton(selectedIndex);
        }

        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex = (selectedIndex + 1) % buttons.Length;
            SelectButton(selectedIndex);
        }

        
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            buttons[selectedIndex].onClick.Invoke();
        }
    }

    void SelectButton(int index)
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            Text text = buttons[i].GetComponentInChildren<Text>();

            if (i == index)
            {
                blinkCoroutine = StartCoroutine(BlinkText(text));
            }
            else
            {
                text.color = new Color(1f, 1f, 1f, 0.4f); 
            }
        }

        EventSystem.current.SetSelectedGameObject(buttons[index].gameObject);
    }

    IEnumerator BlinkText(Text text)
    {
        while (true)
        {
            text.color = HexToColor("#fff000");
            yield return new WaitForSeconds(0.5f);

            text.color = HexToColor("#fff000");
            yield return new WaitForSeconds(0.5f);
        }
    }

    Color HexToColor(string hex)
    {
        hex = hex.Replace("#", "");
        float r = Mathf.Clamp01(int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber) / 255f);
        float g = Mathf.Clamp01(int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber) / 255f);
        float b = Mathf.Clamp01(int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber) / 255f);
        return new Color(r, g, b);
    }
}
