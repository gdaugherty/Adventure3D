using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Bridge : MonoBehaviour
{
    public Transform PortalSpawn;
   
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.transform.position = PortalSpawn.position;            
        }
                           
    }
   
}
