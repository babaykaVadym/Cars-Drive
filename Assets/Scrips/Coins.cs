
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
    }
}
