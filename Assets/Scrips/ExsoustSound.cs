
using UnityEngine;

public class ExsoustSound : MonoBehaviour
{
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("Music") != "no")
        {
            GetComponent<AudioSource>().clip = clips[Random.Range(0, clips.Length)];
            GetComponent<AudioSource>().Play();
        }
    }

}
