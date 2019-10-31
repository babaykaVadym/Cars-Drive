using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploudSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Music") != "no")
            GetComponent<AudioSource>().Play();
    }

  
}
