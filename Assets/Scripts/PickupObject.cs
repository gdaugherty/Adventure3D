using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{

    GameObject CarriedObject;
    public Transform[] objRespawnpoints;
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
            //collidedWith.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            CarriedObject = collidedWith;
            iscarrying = true;
            collidedWith.tag = "Carried";
            audioSource.clip = pickup;
            audioSource.Play();
        }

    }

    void checkDrop()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            iscarrying = false;
            CarriedObject.tag = "Pickup";
            CarriedObject.transform.parent = null;
            CarriedObject.transform.Translate(0.0f, 0.0f, -1.0f);
            audioSource.clip = drop;
            audioSource.Play();
        }
    }

    public void dropObject()
    {
        iscarrying = false;
        CarriedObject.tag = "Pickup";
        CarriedObject.transform.parent = null;
        if (CarriedObject.transform.position.y < -5)
            CarriedObject.transform.position = objRespawnpoints[Random.Range(0, 4)].transform.position;        
    }
  
}
