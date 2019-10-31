using System.Collections;
using UnityEngine;

public class CarLight : MonoBehaviour
{
  
    public int showObject;

    void Start()
    {
        StartCoroutine(light());
        //gameObject.transform.GetChild(showObject).gameObject.SetActive(true);
        if (PlayerPrefs.GetString("Music") != "no")
            StartCoroutine(sound());
    }

    IEnumerator light()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject light = gameObject.transform.GetChild(showObject).gameObject;
        while (true)
        {
            light.SetActive(!light.activeSelf);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator sound()
    {
        GameObject gm = Instantiate(GetComponent <MoveScript> ().turnSignal, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(2f);
        Destroy(gm.gameObject);
    }
}
