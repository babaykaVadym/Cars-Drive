using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public Sprite button, pressed;

    public bool music;

    private Image img;

    private float yPos;
    private Transform childButton;
    
    // Start is called before the first frame update
    void Start()
    {
   
        img = GetComponent<Image>();
        childButton = transform.GetChild(0).transform;

            if (music)
        {
            if (PlayerPrefs.GetString("Music") != "no")
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);

            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                childButton = transform.GetChild(1).transform;
            }
        }
    }

    private void OnMouseDown()
    {
        img.sprite = pressed;
        yPos = childButton.localPosition.y;
        childButton.localPosition = new Vector3(childButton.localPosition.x, 0, childButton.localPosition.z);
    }

    private void OnMouseUp()
    {
        img.sprite = button;
        childButton.localPosition = new Vector3(childButton.localPosition.x, yPos, childButton.localPosition.z);
    }

    private void OnMouseUpAsButton()
    {
        if (PlayerPrefs.GetString("Music") != "no")
            GetComponent<AudioSource>().Play();
            switch (gameObject.name)
        {
            case "Play":
                string scene = PlayerPrefs.HasKey ("Study") ? "game" : "study";

                StartCoroutine(loadScene(scene));
                break;

            case "Replay":
                StartCoroutine(loadScene("game"));
             break;

            case "Close":
                StartCoroutine(loadScene("main"));
                break;

            case "Shop":
                StartCoroutine(loadScene("shop"));
                break;

            case "Home":
                StartCoroutine(loadScene("main"));
                break;

            case "How to":
                StartCoroutine(loadScene("study"));
                break;

            case "Music":
                childButton.gameObject.SetActive(false);
                if(PlayerPrefs.GetString("Music") != "no")
                {
                    PlayerPrefs.SetString("Music", "no");
                    childButton = transform.GetChild(1).transform;
                }
                else
                {
                    PlayerPrefs.DeleteKey("Music");
                    childButton = transform.GetChild(0).transform;
                }

                childButton.gameObject.SetActive(true);
                break;


        }
    }

    IEnumerator loadScene(string scena)
    {
        float fadeTime = Camera.main.GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(scena);
    }

}
