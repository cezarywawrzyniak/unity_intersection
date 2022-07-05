using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianLights : MonoBehaviour
{
    /*
    0 = All Stop
    1 = SouthWest1
    2 = SouthWest2
    3 = SouthEast1
    4 = SouthEast2
    5 = EastSouth1
    6 = EastSouth2
    7 = EastNorth1
    8 = EastNorth2
    */

    public GameObject crossing;
    public Material red;
    public Material green;
    public int id;

    private CrossControl crossControlScript;
    private Collider lightCollider;
    private bool flag;

    void Start()
    {
        flag = false;
        crossControlScript = crossing.GetComponent<CrossControl>();
        lightCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        switch (id)
        {   
            case 0:
                break;
            case 1:
                if (collision.gameObject.tag == "pedestrianSE")
                {
                    Physics.IgnoreCollision(collision.collider, lightCollider);
                }
                break;
            case 2:
                if (collision.gameObject.tag == "pedestrianSW")
                {
                    Physics.IgnoreCollision(collision.collider, lightCollider);
                }
                break;
            case 3:
                if (collision.gameObject.tag == "pedestrianSW")
                {
                    Physics.IgnoreCollision(collision.collider, lightCollider);
                }
                break;
            case 4:
                if (collision.gameObject.tag == "pedestrianSE")
                {
                    Physics.IgnoreCollision(collision.collider, lightCollider);
                }
                break;
            case 5:
                if (collision.gameObject.tag == "pedestrianEN")
                {
                    Physics.IgnoreCollision(collision.collider, lightCollider);
                }
                break;
            case 6:
                if (collision.gameObject.tag == "pedestrianES")
                {
                    Physics.IgnoreCollision(collision.collider, lightCollider);
                }
                break;
            case 7:
                if (collision.gameObject.tag == "pedestrianES")
                {
                    Physics.IgnoreCollision(collision.collider, lightCollider);
                }
                break;
            case 8:
                if (collision.gameObject.tag == "pedestrianEN")
                {
                    Physics.IgnoreCollision(collision.collider, lightCollider);
                }
                break;
        }
        
    }

    void Update()
    {
        switch(id)
        {
            case 0:
                break;
            case 1:
            case 2:
                if (crossControlScript.southWest)
                {
                    if (flag == false)
                    {
                        StartCoroutine(GreenLight());
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    StopAllCoroutines();
                    RedLight();
                }
            break;
            case 3:
            case 4:
                if (crossControlScript.southEast)
                {
                    if (flag == false)
                    {
                        StartCoroutine(GreenLight());
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    StopAllCoroutines();
                    RedLight();
                }
                break;
            case 5:
            case 6:
                if (crossControlScript.eastSouth)
                {
                    if (flag == false)
                    {
                        StartCoroutine(GreenLight());
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    StopAllCoroutines();
                    RedLight();
                }
                break;
            case 7:
            case 8:
                if (crossControlScript.eastNorth)
                {
                    if (flag == false)
                    {
                        StartCoroutine(GreenLight());
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                    StopAllCoroutines();
                    RedLight();
                }
                break;

        }
    }
    IEnumerator GreenLight()
    {
        yield return new WaitForSeconds(5f);
        this.GetComponent<Renderer>().sharedMaterial = green;
        lightCollider.enabled = false;
    }
    public void RedLight()
    {
        this.GetComponent<Renderer>().sharedMaterial = red;
        lightCollider.enabled = true;
    }
}
