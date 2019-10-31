using System.Collections;
using UnityEngine.UI ;
using UnityEngine;

public class BuySlow : MonoBehaviour
{
    public Text count, coins;

    // Start is called before the first frame update
    void Start()
    {
        count.text = PlayerPrefs.GetInt("Slow").ToString();

    }

    private void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetInt ("Coins") > 100)
        {
            PlayerPrefs.SetInt("Slow", PlayerPrefs.GetInt("Slow") + 1);
            count.text = PlayerPrefs.GetInt("Slow").ToString();
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 100);
            coins.text = PlayerPrefs.GetInt("Coins").ToString();
        }
    }


}
