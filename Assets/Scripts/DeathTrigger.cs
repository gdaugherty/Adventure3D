using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    //A reference to the game manager
    public GameManager gameManager;
    AudioSource audioSource;

    // Triggers when the player enters the water
    void OnTriggerEnter(Collider collider)
    {
        audioSource = GetComponent<AudioSource>();
        GameObject CollidedWith = collider.gameObject;
        if (CollidedWith.tag == "Player")
        {
            gameManager.DeadPlayer();
            gameManager.PositionPlayer();
            audioSource.Play();
        }
    }
}
