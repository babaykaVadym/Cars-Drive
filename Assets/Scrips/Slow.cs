using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Slow : MonoBehaviour
{
    private Text countSlow;
    public Sprite active, inactive;
    private void Start()
    {
        countSlow = gameObject.transform.GetChild(0).transform.GetComponent<Text>();
        
        if (PlayerPrefs.HasKey("Slow Time"))
        {
            PlayerPrefs.SetInt("Slow Time", 3);
            countSlow.text = "3";
        }
        else
        {
            countSlow.text = PlayerPrefs.GetInt("Slow Time").ToString();
        }

        if(PlayerPrefs.GetInt("Slow Time") == 0)
        {
            GetComponent<Image>().sprite = inactive;
        } else GetComponent<Image>().sprite = active;
    }
    private void OnMouseDown()
    {
        if (PlayerPrefs.GetInt("Slow Time") > 0 && Time.timeScale !=0.5f)
        {
            if (PlayerPrefs.GetString("Music") != "no")
                GetComponent<AudioSource>().Play();
            PlayerPrefs.GetInt("Slow Time", PlayerPrefs.GetInt("Slow Time") - 1);
            countSlow.text = PlayerPrefs.GetInt("Slow Time").ToString();
            if (PlayerPrefs.GetInt("Slow Time") == 0)
            {
                GetComponent<Image>().sprite = inactive;
            }
                StartCoroutine(slow());
        }
    }


    IEnumerator slow()
    {
        Time.timeScale = 0.5f; 
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
