using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSpawning : MonoBehaviour
{
    /*-------------ID--------------
    9 = SW
    10 = SE
    11 = ES
    12 = EN
     */
    private string spawnCode;

    public int id;
    public int spawnNumber;
    public int pedestrianCount;

    public bool read;

    public GameObject fem1;
    public GameObject fem2;
    public GameObject fem3;
    public GameObject fem4;
    public GameObject male1;
    public GameObject male2;
    public GameObject male3;
    public GameObject male4;

    public List<GameObject> pedestrianList;

    public GameObject crossing;

    private CrossControl crossControlScript;

    public float zMax;
    public float zMin;
    public float xMax;
    public float xMin;
    public float spawnerTime;
    void Start()
    {
        crossControlScript = crossing.GetComponent<CrossControl>();

        InvokeRepeating("Spawning", 0.5f, spawnerTime);
        pedestrianCount = 0;

        pedestrianList.Add(fem1);
        pedestrianList.Add(fem2);
        pedestrianList.Add(fem3);
        pedestrianList.Add(fem4);
        pedestrianList.Add(male1);
        pedestrianList.Add(male2);
        pedestrianList.Add(male3);
        pedestrianList.Add(male4);

    }

    private void Update()
    {
        if (read)
        {
            spawnCode = crossControlScript.spawnCodes[id];
            spawnNumber = (int)(spawnCode[0] - '0');
            spawnCode = null;
            read = false;
            
        }
    }

    private void Spawning()
    {
        if (spawnNumber > 0 && spawnNumber <= 3)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(xMin,xMax), transform.position.y, transform.position.z + Random.Range(zMin, zMax));
            int pedestrianSpawn = Random.Range(0, 8);
            Instantiate(pedestrianList[pedestrianSpawn], spawnPosition, pedestrianList[pedestrianSpawn].transform.rotation);
            pedestrianCount++;
            spawnNumber--;
        }
        else if (spawnNumber > 3)
        {
            spawnNumber = 3;
        }
        else if (spawnNumber < 0)
        {
            spawnNumber = 0;
        }

    }
    public void StartReading()
    {
        read = true;
    }
}
