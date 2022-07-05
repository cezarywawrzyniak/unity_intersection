using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTurn : MonoBehaviour
{
    public GameObject carColliderObject;
    private Collider carCollider;
    public GameObject carBlockObject;
    private Collider carBlock;

    void Start()
    {
        carCollider = carColliderObject.GetComponent<Collider>();
        carBlock = carBlockObject.GetComponent<Collider>();
        carCollider.enabled = false;
        carBlock.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "pedestrianSW" || other.gameObject.tag == "pedestrianSE")
        {
            carCollider.enabled = true;
            carBlock.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pedestrianSW" || other.gameObject.tag == "pedestrianSE")
        {
            carCollider.enabled = false;
            carBlock.enabled = false;
        }
    }
}
