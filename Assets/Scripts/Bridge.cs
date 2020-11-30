using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Bridge : MonoBehaviour
{
    public GameObject realmTerrain;
    private TerrainCollider tcollider;

    void Start()
    {
        tcollider = realmTerrain.GetComponent<TerrainCollider>();        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            tcollider.enabled = false;            
        }
                           
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            tcollider.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            tcollider.enabled = true;
        }
    }

}
