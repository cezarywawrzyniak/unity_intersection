using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /*-------------ID--------------
    0 = WS1
    1 = WS2
    2 = WR
    3 = ES1
    4 = ES2
    5 = EL
    6 = SR
    7 = SL2
    8 = SL1
     */

    public int id;

    public bool read;
    public bool isSpawningCar1;
    public bool isSpawningBus;
    public bool isSpawningCar2;

    public float spawnTimeCar;
    public float spawnTimeBus;

    public GameObject blueCar;
    public GameObject grayCar;
    public GameObject midnightCar;
    public GameObject orangeCar;
    public GameObject redCar;
    public GameObject yellowCar;

    public List<int> spawnNumber = new List<int> { };
    public List<GameObject> carList;

    public GameObject bus;

    public GameObject crossing;
    private CrossControl crossControlScript;

    public GameObject counter;
    private Counter counterScript;

    void Start()
    {
        spawnNumber = new List<int> { 0, 0, 0 };

        crossControlScript = crossing.GetComponent<CrossControl>();
        counterScript = counter.GetComponent<Counter>();


        read = false;
        isSpawningCar1 = false;
        isSpawningBus = false;
        isSpawningCar2 = false;

        carList.Add(blueCar);
        carList.Add(grayCar);
        carList.Add(midnightCar);
        carList.Add(orangeCar);
        carList.Add(redCar);
        carList.Add(yellowCar);

        InvokeRepeating("SpawningCar1", 0.5f, spawnTimeCar);
        InvokeRepeating("SpawningCar2", 0.5f, spawnTimeCar);
        InvokeRepeating("SpawningBus", 0.5f, spawnTimeBus);
    }
    private void Update()
    {
        if(read)
        {
            StartCoroutine(WaitForSpawn());
            read = false;
        }
        
    }

    IEnumerator WaitForSpawn()
    {
        string spawnCode = crossControlScript.spawnCodes[id];
        Debug.Log(spawnCode);

        yield return new WaitUntil(() => (isSpawningCar1 == false && isSpawningBus == false && isSpawningCar2 == false));


        for (int i = 0; i < spawnCode.Length; i++)
        {
            spawnNumber[i] = (int)(spawnCode[i] - '0');
        }
        //spawnCode = null;
        if (spawnNumber != null)
        {
            isSpawningCar1 = true;
        }
    }

    public void StartReading()
    {
        read = true;
    }

    private void SpawningCar1()
    {
        if(isSpawningCar1)
        {
            if (spawnNumber[0] > 0 && spawnNumber[0] <= 6)
            {
                int carSpawn = Random.Range(0, 6);
                Instantiate(carList[carSpawn], transform.position, transform.rotation);
                counterScript.carsCount++;
                spawnNumber[0]--;
            }
            else if (spawnNumber[0] > 6)
            {
                spawnNumber[0] = 6;
            }
            else if (spawnNumber[0] < 0)
            {
                spawnNumber[0] = 0;
            }
            else if (spawnNumber[0] == 0)
            {
                if (spawnNumber[1] > 0)
                {
                    StartCoroutine(ChangeToBus());
                }
                else
                {
                    isSpawningCar1 = false;
                    isSpawningBus = true;
                }
                       
            }

        }  
    }

    IEnumerator ChangeToBus()
    {
        yield return new WaitForSeconds(0.25f);
        isSpawningCar1 = false;
        isSpawningBus = true;
    }


    private void SpawningBus()
    {
        if (isSpawningBus)
        {
            if (spawnNumber[1] > 0 && spawnNumber[1] <= 2)
            {
                Instantiate(bus, transform.position, transform.rotation);
                counterScript.busesCount++;
                spawnNumber[1]--;
            }
            else if (spawnNumber[1] > 2)
            {
                spawnNumber[1] = 2;
            }
            else if (spawnNumber[1] < 0)
            {
                spawnNumber[1] = 0;
            }
            else if (spawnNumber[1] == 0)
            {
                if (spawnNumber[2] > 0)
                {
                    StartCoroutine(ChangeFromBus());
                }
                else
                {
                    isSpawningBus = false;
                    isSpawningCar2 = true;
                }

            }


        }
    }

    IEnumerator ChangeFromBus()
    {   
        yield return new WaitForSeconds(0.25f);
        isSpawningBus = false;
        isSpawningCar2 = true;
    }

    private void SpawningCar2()
    {
        if (isSpawningCar2)
        {
            if (spawnNumber[2] > 0 && spawnNumber[2] <= 6)
            {
                int carSpawn = Random.Range(0, 6);
                Instantiate(carList[carSpawn], transform.position, transform.rotation);
                counterScript.carsCount++;
                spawnNumber[2]--;
            }
            else if (spawnNumber[2] > 6)
            {
                spawnNumber[2] = 6;
            }
            else if (spawnNumber[2] < 0)
            {
                spawnNumber[2] = 0;
            }
            else if (spawnNumber[2] == 0)
            {
                isSpawningCar2 = false;
            }

        }
    }

}
