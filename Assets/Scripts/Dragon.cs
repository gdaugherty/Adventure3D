using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{

    public GameObject deadDragon;
    public GameObject attackDragon;
    public GameManager gameManager;
    private bool isInside = false;

    
    void OnTriggerEnter(Collider collider)
    {
        isInside = true;
        if (collider.tag == "Sword")
        {
            transform.localScale = new Vector3(0, 0, 0);
            deadDragon.transform.localScale = new Vector3(1, 1, 1);
            deadDragon.transform.position = transform.position;
            deadDragon.GetComponent<Animator>().Play("dragondeath");
        }
        if (collider.tag == "Player")
        {
            transform.localScale = new Vector3(0, 0, 0);
            attackDragon.transform.localScale = new Vector3(1, 1, 1);
            attackDragon.transform.position = transform.position;
            StartCoroutine(Attack());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        isInside = true;
    }

    void OnTriggerExit(Collider other)
    {
        isInside = false;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.0f);
        if (isInside)
        {
            gameManager.DeadPlayer();
            gameManager.PositionPlayer();

        }
        attackDragon.transform.localScale = new Vector3(0, 0, 0);
        transform.localScale = new Vector3(1, 1, 1);


    }
}
