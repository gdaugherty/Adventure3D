using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    public float pullSpeed;

    private GameObject pullObject;
    private bool isAttractive;


    private void FixedUpdate()
    {
        if (isAttractive)
        {
            pullObject.GetComponent<Rigidbody>().AddForce((transform.position - pullObject.transform.position) * pullSpeed * Time.smoothDeltaTime);

            if (Mathf.Abs(transform.position.x - pullObject.transform.position.x) < 0.5)
            {
                pullObject.transform.position = transform.position;
            }
        }
        else
        {
            pullObject.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            isAttractive = true;
            pullObject = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pickup")
        {
            isAttractive = true;
            pullObject = other.gameObject;
        }
        else
        {
            isAttractive = false;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isAttractive = false;
        
    }

}
