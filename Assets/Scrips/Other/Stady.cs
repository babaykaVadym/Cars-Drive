using System.Collections;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent (typeof (MoveScript))]
public class Stady : MonoBehaviour
{
    public GameObject turnCar;
    public Text study;
    private bool firstStep;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MoveScript>().speed = 0f;
        Invoke("MoveCar", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z <101f && !firstStep)
        {
            firstStep = true;
            GetComponent<MoveScript>().speed = 2f;
            study.text = "Tap the car to accelerate it.";
        }
    }

    void MoveCar()
    {
        GetComponent<MoveScript>().speed = 11f; 
    } 

    private void OnMouseDown()
    {
        if (firstStep)
        {
            GetComponent<MoveScript>().speed = 30f;
            study.text = "";
        }
    }

    private void OnDisable()
    {
        PlayerPrefs.SetString("Study", "Done");
        turnCar.SetActive(true);
    }
}
