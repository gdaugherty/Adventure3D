using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{

    GameObject CarriedObject;
    bool iscarrying;
    public AudioClip pickup;
    public AudioClip drop;
    AudioSource audioSource;

    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager.dropped += dropObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (iscarrying == true)
        {
            checkDrop();
        }        
        
    }

    void OnTriggerEnter(Collider collider)
    {
        GameObject collidedWith = collider.gameObject;
        if ((collidedWith.tag == "Pickup") && (iscarrying == false))
        {
            collidedWith.transform.parent = GetComponent<Transform>().transform;
            CarriedObject = collidedWith;
            iscarrying = true;
            audioSource.clip = pickup;
            audioSource.Play();
        }

    }

    void checkDrop()
    {
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            iscarrying = false;
            CarriedObject.transform.parent = null;
            CarriedObject.transform.Translate(0.0f, 0.0f, -1.0f);
            audioSource.clip = drop;
            audioSource.Play();
        }
    }

    public void dropObject()
    {
        iscarrying = false;
        CarriedObject.transform.parent = null;
    }
  
}
