using UnityEngine;
using UnityEngine.UI;

public class PremioManager : MonoBehaviour
{
    public Text premioText; 

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("scoreToKeep", 0);

        premioText.gameObject.SetActive(false);
        
        if (finalScore >= 10 && finalScore <= 13)
        {
            premioText.text = "Premio: Bala!";
            premioText.gameObject.SetActive(true);
        }
        else if (finalScore >= 13 && finalScore <= 17)
        {
            premioText.text = "Premio: Pirulito!";
            premioText.gameObject.SetActive(true);
        }      
    }
}
