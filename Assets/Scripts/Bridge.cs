using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Bridge : MonoBehaviour
{
    public GameManager gameManager;
    public Transform PortalSpawn;
   
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            gameManager.Teleport(PortalSpawn);            
        }
                           
    }
   
}
