using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    AudioSource audioSource;
    void OnTriggerEnter (Collider collider)
    {

        audioSource = GetComponent<AudioSource>();
        GameObject collidedWith = collider.gameObject;
        if (collidedWith.tag == gameObject.tag)
        {
            GetComponent<Animator>().Play("GateRising");
            audioSource.Play();
        }
    }
}
