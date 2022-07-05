using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianDestroyer : MonoBehaviour
{
    /*
    0 = All Stop
    1 = SW
    2 = SE
    3 = ES
    4 = EN
    */

    public int id;

    public GameObject sign;
    private PedestrianSpawning spawnScirpt;

    private void Start()
    {
        spawnScirpt = sign.GetComponent<PedestrianSpawning>();
    }
    void OnCollisionEnter(Collision coll)
    {
        switch (id)
        {
            case 0:
                break;
            case 1:
                if (coll.gameObject.tag == "pedestrianSW")
                {
                    Destroy(coll.gameObject);
                }
                break;
            case 2:
                if (coll.gameObject.tag == "pedestrianSE")
                {
                    Destroy(coll.gameObject);
                }
                break;
            case 3:
                if (coll.gameObject.tag == "pedestrianES")
                {
                    Destroy(coll.gameObject);
                }
                break;
            case 4:
                if (coll.gameObject.tag == "pedestrianEN")
                {
                    Destroy(coll.gameObject);
                }
                break;
        }
        spawnScirpt.pedestrianCount--;
    }
}
