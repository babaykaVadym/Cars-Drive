﻿
using UnityEngine;

public class DeletCars : MonoBehaviour
{
    public static int countCars;

    private void Start()
    {
        countCars = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(!CollisionCars.lose)
            countCars++;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
           
        }
        Destroy(other.gameObject);
    }
}
