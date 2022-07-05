using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    /*
    0 = All Stop
    1 = West Straight
    2 = West Right
    3 = East Straight
    4 = East Left
    5 = South Right
    6 = South Left
    */

    public GameObject crossing;
    public Material red;
    public Material green;
    public int id;
    private bool flag;

    private CrossControl crossControlScript;
    private Collider lightCollider;

    void Start()
    {
        flag = false;
        crossControlScript = crossing.GetComponent<CrossControl>();
        lightCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cars" || collision.gameObject.tag == "buses")
        {
            Physics.IgnoreCollision(collision.collider, lightCollider);
        }
    }

    void Update()
    {
        switch (id)
        {
            case 0:
                break;
            case 1:
                if (crossControlScript.westStraight)
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
            case 2:
                if (crossControlScript.westRight)
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
                if (crossControlScript.eastStraight)
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
            case 4:
                if (crossControlScript.eastLeft)
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
                if (crossControlScript.southRight)
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
            case 6:
                if (crossControlScript.southLeft)
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
