using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{

    public GameObject deadDragon;

    void OnTriggerEnter(Collider collider)
    {
        
        GameObject CollidedWith = collider.gameObject;

        if (CollidedWith.tag == "Sword")
        {
            transform.localScale = new Vector3(0, 0, 0);

            //deadDragon.transform.localScale = new Vector3(1, 1, 1);
            deadDragon.GetComponent<Animator>().Play("dragondeath");
        }
    }
}
