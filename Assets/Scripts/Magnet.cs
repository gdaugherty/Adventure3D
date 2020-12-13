using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{

    public float pullSpeed;
    public List<GameObject> magneticItems;

    private GameObject pullObject;
    private bool isAttractive;


    private void FixedUpdate()
    {
        if (isAttractive)
        {
            pullObject.GetComponent<Rigidbody>().AddForce((transform.position - pullObject.transform.position) * pullSpeed * Time.smoothDeltaTime);

            if (Mathf.Abs(transform.position.x - pullObject.transform.position.x) < 0.5f)
            {
                pullObject.transform.position = transform.position;
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Pickup") && magneticItems.Contains(other.gameObject))
        {
            pullObject = other.gameObject;
            isAttractive = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Pickup") && magneticItems.Contains(other.gameObject))
        {
            pullObject = other.gameObject;
            isAttractive = true;
        }
        else if (other.tag == "Carried")
        {
            isAttractive = false;
            other.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isAttractive = false;
        if ((other.tag == "Pickup") && magneticItems.Contains(other.gameObject))
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (other.tag == "Carried")
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
