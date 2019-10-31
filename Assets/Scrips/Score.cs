using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text topRecord; 

    private void OnEnable()
    {
        GetComponent<Text>().text = "Score: " + DeletCars.countCars.ToString();
        if(PlayerPrefs.GetInt("Score")< DeletCars.countCars)
        {
            PlayerPrefs.SetInt("Score", DeletCars.countCars);
            topRecord.text = "Top: " + DeletCars.countCars.ToString();

        }
        else
        {
            topRecord.text = "Top: " + PlayerPrefs.GetInt("Score").ToString();
        }

    }
}
