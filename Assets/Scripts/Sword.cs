using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    AudioSource audioSource;

    void OnTriggerEnter(Collider collider)
    {
        audioSource = GetComponent<AudioSource>();
        GameObject CollidedWith = collider.gameObject;

        if (CollidedWith.tag == "Sword")
        {
            audioSource.Play();
        }
    }
}
