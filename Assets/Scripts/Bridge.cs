using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public Transform PortalSpawn;  

    void OnTriggerEnter(Collider collider)
    {
        GameObject CollidedWith = collider.gameObject;

        if (CollidedWith.tag == "Player")
        {
            CollidedWith.transform.position = PortalSpawn.position;
        }
                           
    }
   
}
