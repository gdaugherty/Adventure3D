using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    //A reference to the game manager
    public GameManager gameManager;
    public Transform chaliceWinPoint;
    public GameObject chalice;

    AudioSource audioSource;

    // When an object enters the finish zone, let the
    // game manager know that the current game has ended
    void OnTriggerEnter(Collider collider)
    {
        audioSource = GetComponent<AudioSource>();
        GameObject collidedWith = collider.gameObject;
        if (collidedWith.tag == gameObject.tag)
        {
            chalice.transform.position = chaliceWinPoint.position;
            chalice.transform.rotation = chaliceWinPoint.rotation;
            gameManager.FinishedGame();
            audioSource.Play();
        }
    }
}
