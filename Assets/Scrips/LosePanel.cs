using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject losePanel, slowTime;
    private bool addOnce; 
    // Update is called once per frame
    void Update()
    {
        if (CollisionCars.lose && !addOnce)
        {
            addOnce = true;
            slowTime.SetActive(false);
            losePanel.SetActive (true );

        }
    }
}
