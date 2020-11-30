using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject deadDragon;    
    public GameManager gameManager;
    private bool isInside = false;
    private MeshFilter mFilter;
    AudioSource audioSource;
    public AudioClip chomp;
    public AudioClip swallow;


    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        deadDragon.transform.localScale = new Vector3(0, 0, 0);        
        mFilter = GetComponent<MeshFilter>();
        audioSource = GetComponent<AudioSource>();
    }



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
            agent.isStopped = true;
            mFilter.mesh = Resources.Load<Mesh>("DragonAttack");
            audioSource.clip = chomp;
            audioSource.Play();
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
        isInside = true;
        yield return new WaitForSeconds(1.0f);
        if (isInside)
        {
            gameManager.DeadPlayer();
            gameManager.PositionPlayer();
            //gameManager.SpawnDragons();
            audioSource.clip = swallow;
            audioSource.Play();
        }

        agent.isStopped = false;
        mFilter.mesh = Resources.Load<Mesh>("Dragon");
        

    }
}
