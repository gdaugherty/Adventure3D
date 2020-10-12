using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private List<GameObject> pullObjects;
    public float pullSpeed;
    private Vector3 pullDirection;

    // Start is called before the first frame update
    void Start()
    {
        pullObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        
        foreach (GameObject obj in pullObjects)
        {
            pullDirection = transform.position - obj.transform.position;
            //Debug.Log(pullDirection);
            obj.transform.Translate(Time.deltaTime * pullSpeed * pullDirection);
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            Debug.Log("Object Entered");
            pullObjects.Add(other.gameObject);
            pullDirection = (transform.position);
        }
       
    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Object Exited");
        pullObjects.Remove(other.gameObject);
        pullDirection = (transform.position);
    }
}
