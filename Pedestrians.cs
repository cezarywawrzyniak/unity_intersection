using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrians : MonoBehaviour
{
    /*
    0 = All Stop
    1 = SW
    2 = SE
    3 = ES
    4 = EN
    */
    public int id;

    public float speed = 2.5f;
    public float sensorLength = 0.8f;

    private Animator animator;
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

   

    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position;
        sensorStartPos.y += 0.3f;

        switch (id)
        {
            case 0:
                break;
            case 1:
                Vector3 xPlus =  new Vector3(1, 0, 0);

                if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
                {
                    if (hit.transform.tag == "destroyers" || hit.transform.name == "SW2" || hit.transform.name == "SE1" || hit.transform.tag == "pedestrianSE" || hit.transform.tag == "rightTurn")
                    {
                        body.MovePosition(body.position + xPlus.normalized * speed * Time.fixedDeltaTime);
                        animator.SetBool("isWalking", true);
                    }
                    else
                    {
                        animator.SetBool("isWalking", false);
                    }

                    Debug.DrawLine(sensorStartPos, hit.point);
                }
                else
                {

                    body.MovePosition(body.position + xPlus.normalized * speed * Time.fixedDeltaTime);
                    animator.SetBool("isWalking", true);
                }
                break;
            case 2:

                Vector3 xMinus = new Vector3(-1, 0, 0);
                if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
                {
                    if (hit.transform.tag == "destroyers" || hit.transform.name == "SW1" || hit.transform.name == "SE2" || hit.transform.tag == "pedestrianSW" || hit.transform.tag == "rightTurn")
                    {
                        
                        body.MovePosition(body.position + xMinus.normalized * speed * Time.fixedDeltaTime);
                        animator.SetBool("isWalking", true);
                    }
                    else
                    {
                        animator.SetBool("isWalking", false);
                    }

                    Debug.DrawLine(sensorStartPos, hit.point);
                }
                else
                {

                    body.MovePosition(body.position + xMinus.normalized * speed * Time.fixedDeltaTime);
                    animator.SetBool("isWalking", true);
                }
                break;
            case 3:

                Vector3 zPlus = new Vector3(0, 0, 1);
                if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
                {
                    if (hit.transform.tag == "destroyers" || hit.transform.name == "EN1" || hit.transform.name == "ES2" || hit.transform.tag == "pedestrianEN" || hit.transform.tag == "rightTurn")
                    {

                        body.MovePosition(body.position + zPlus.normalized * speed * Time.fixedDeltaTime);
                        animator.SetBool("isWalking", true);
                    }
                    else
                    {
                        animator.SetBool("isWalking", false);
                    }

                    Debug.DrawLine(sensorStartPos, hit.point);
                }
                else
                {

                    body.MovePosition(body.position + zPlus.normalized * speed * Time.fixedDeltaTime);
                    animator.SetBool("isWalking", true);
                }
                break;
            case 4:

                Vector3 zMinus = new Vector3(0, 0, -1);
                if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLength))
                {
                    
                    if (hit.transform.tag == "destroyers" || hit.transform.name == "EN2" || hit.transform.name == "ES1" || hit.transform.tag == "pedestrianES" || hit.transform.tag == "rightTurn")
                    {

                        body.MovePosition(body.position + zMinus.normalized * speed * Time.fixedDeltaTime);
                        animator.SetBool("isWalking", true);
                    }
                    else
                    {
                        animator.SetBool("isWalking", false);
                    }

                    Debug.DrawLine(sensorStartPos, hit.point);
                }
                else
                {

                    body.MovePosition(body.position + zMinus.normalized * speed * Time.fixedDeltaTime);
                    animator.SetBool("isWalking", true);
                }
                break;
        }

    }
     
       
}
