using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarTurn : MonoBehaviour
{
    public Text study;


    // Start is called before the first frame update
    void Start()
    {
        study.text = "Watch where the car turns";  
    }

    private void OnDisable()
    {
        SceneManager.LoadScene("game");
    }
}
