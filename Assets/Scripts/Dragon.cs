using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject deadDragon;    
    public GameManager gameManager;
   
    AudioSource audioSource;
    public AudioClip chomp;
    public AudioClip swallow;

    private bool isInside = false;
    private MeshFilter mFilter;

    public GameObject[] DragonSpawnpoints;



    void Start()
    {
        //SpawnDragons();

        agent = this.GetComponent<NavMeshAgent>();
        deadDragon.transform.localScale = new Vector3(0, 0, 0);        
        mFilter = GetComponent<MeshFilter>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (gameManager.isDead)
        {
            SpawnDragons();
            deadDragon.GetComponent<Animator>().Play("static");
            deadDragon.transform.localScale = new Vector3(0, 0, 0);

            mFilter.mesh = Resources.Load<Mesh>("Dragon");
            transform.localScale = new Vector3(1, 1, 1);

            agent.isStopped = false;
            gameManager.PositionPlayer();
        }

        if (gameManager.isFinished)
            agent.isStopped = true;
    }

    public void SpawnDragons()
    {
        transform.position = DragonSpawnpoints[Random.Range(0, 4)].transform.position;
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
            audioSource.clip = swallow;
            audioSource.Play();
            gameManager.DeadPlayer();
            mFilter.mesh = Resources.Load<Mesh>("Dragon");
            agent.isStopped = false;
        }
        else
        {
            mFilter.mesh = Resources.Load<Mesh>("Dragon");
            agent.isStopped = false;
        }   

    }
}
