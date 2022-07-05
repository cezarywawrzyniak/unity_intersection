using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
  
    
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "cars" || coll.gameObject.tag == "buses")
        {
            Destroy(coll.gameObject);
        }
    }
}

