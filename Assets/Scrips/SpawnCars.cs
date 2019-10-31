using System.Collections;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    [SerializeField]
    private bool mainScene;
    public GameObject[] cars;
    private float startSpawn = 0.5f;
    private float waitSpawn;
    private int countCars = 0;
    private bool onceStop;

    private void Start()
    {
        StartCoroutine(westCars());
        StartCoroutine(eastCars());
        StartCoroutine(southCars());
        StartCoroutine(northCars());

        waitSpawn = mainScene ? 7f : 2f;

        CollisionCars.lose = false;
    }

    private void Update()
    {
        if (!mainScene)
        {

            if (countCars > 60) waitSpawn = 0.5f;
            else if (countCars > 40) waitSpawn = 1f;
            else if (countCars > 20) waitSpawn = 1.5f;
        }
        if (CollisionCars.lose)
        {
            StopAllCoroutines();
            onceStop = true;
        }
    }

    IEnumerator westCars()
    {
        yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));
        while (true)
        {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(1.9f, 0.6f, 65f),
                Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            countCars++;

            int rand = mainScene ? 2 : Random.Range(0, 4);


            switch (rand)
            {
                case 1:
                    carInst.AddComponent<WestTurnLeft>();
                    break;

                case 2:
                    carInst.AddComponent<WestTurnRight>();
                    break;

            }
            yield return new WaitForSeconds(Random.Range(waitSpawn, waitSpawn + 5f));
        }


    }
    IEnumerator eastCars()
    {
        yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));
        while (true)
        {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(-1.2f, 0.6f, 109f),
                Quaternion.Euler(new Vector3(0, 180, 0))) as GameObject;
            countCars++;
            int rand = mainScene ? 2 : Random.Range(0, 4);
            switch (rand)
            {
                case 1:
                    carInst.AddComponent<EastTurnLeft>();
                    break;

                case 2:
                    carInst.AddComponent<EastTurnRight>();
                    break;

            }
            yield return new WaitForSeconds(Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }

    IEnumerator southCars()
    {
        yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));
        while (true)
        {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(17f, 0.6f, 91f),
                Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
            countCars++;
            int rand = mainScene ? 2 : Random.Range(0, 4);
            switch (rand)
            {
                case 1:
                    carInst.AddComponent<SouthTurnLeft>();
                    break;

                case 2:
                    carInst.AddComponent<SouthTurnRight>();
                    break;

            }
            yield return new WaitForSeconds(Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }


    IEnumerator northCars()
    {
        yield return new WaitForSeconds(Random.Range(startSpawn, startSpawn + 4.5f));
        while (true)
        {
            GameObject carInst = Instantiate(cars[Random.Range(0, cars.Length)], new Vector3(-20f, 0.6f, 87.7f),
                Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
            countCars++;
            int rand = mainScene? 2: Random.Range(0, 4);
            switch (rand)
            {
                case 1:
                    carInst.AddComponent<NorthTurnLeft>();
                    break;

                case 2:
                    carInst.AddComponent<NorthTurnRight>();
                    break;

            }
            yield return new WaitForSeconds(Random.Range(waitSpawn, waitSpawn + 5f));
        }
    }

}
