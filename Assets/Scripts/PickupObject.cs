using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{

    GameObject CarriedObject;
    bool carrying;
    AudioSource audioSource;
    


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (carrying == true)
        {
            checkDrop();
        }
        
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject collidedWith = collider.gameObject;
        if ((collidedWith.tag == "Pickup") && (carrying == false))
        {
            collidedWith.transform.parent = GetComponent<Transform>().transform;
            CarriedObject = collidedWith;
            carrying = true;
            audioSource.Play();
        }

    }

    void checkDrop()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        carrying = false;
        CarriedObject.transform.parent = null;
        CarriedObject.transform.Translate(0.0f, 0.0f, -1.0f);
        audioSource.Play();
    }
  
}
