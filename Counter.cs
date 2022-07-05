using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int carsCount;
    public int busesCount;

    private Collider counterColl;

    void Start()
    {
        counterColl = GetComponent<Collider>();   
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "cars")
        {
            carsCount--;
        }
        else if (collision.gameObject.tag == "buses")
        {
            busesCount--;
        }
    }
}
