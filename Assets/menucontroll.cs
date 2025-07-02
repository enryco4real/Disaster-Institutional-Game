using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControll : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void creditos()
    {
        SceneManager.LoadScene("EasterEgg");

    }

    public void SceneLoadFase1()
    {
        SceneManager.LoadScene("Fase1");
    }

}
