using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonAI : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject target;
    public GameObject[] protectionObjs;
    private Rigidbody rbBody;

    float currentSpeed
    {
        get { return rbBody.velocity.magnitude; }
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        rbBody = target.GetComponent<Rigidbody>();
    }

    public void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public void Flee(Vector3 location)
    {
        Vector3 fleeVector = location - this.transform.position;
        agent.SetDestination(this.transform.position - fleeVector);
    }

    public void Pursue()
    {
        Vector3 targetDir = target.transform.position - this.transform.position;

        float relativeHeading = Vector3.Angle(this.transform.forward, this.transform.TransformVector(target.transform.forward));

        float toTarget = Vector3.Angle(this.transform.forward, this.transform.TransformVector(targetDir));

        if ((toTarget > 90 && relativeHeading < 20) || currentSpeed < 0.01f)
        {
            Seek(target.transform.position);
            return;
        }

        float lookAhead = targetDir.magnitude / (agent.speed + currentSpeed);
        Seek(target.transform.position + target.transform.forward * lookAhead);
    }

    public void Evade()
    {
        Vector3 targetDir = target.transform.position - this.transform.position;
        float lookAhead = targetDir.magnitude / (agent.speed + currentSpeed);
        Flee(target.transform.position + target.transform.forward * lookAhead);
    }


    Vector3 wanderTarget = Vector3.zero;

    public void Wander()
    {
        float wanderRadius = 100;
        float wanderDistance = 100;
        float wanderJitter = 10;

        wanderTarget += new Vector3(Random.Range(-1.0f, 1.0f) * wanderJitter, 0, Random.Range(-1.0f, 1.0f) * wanderJitter);
        wanderTarget.Normalize();
        wanderTarget *= wanderRadius;

        Vector3 targetLocal = wanderTarget + new Vector3(0, 0, wanderDistance);
        //Vector3 targetWorld = this.gameObject.transform.InverseTransformVector(targetLocal);

        Seek(transform.position + targetLocal);
    }

    public void Protect()
    {
        float dist = Mathf.Infinity;
        Vector3 chosenObj = Vector3.zero;

        for (int i = 0; i < protectionObjs.Length; i++)
        {
            Vector3 objDir = protectionObjs[i].transform.position - target.transform.position;
            Vector3 objPos = protectionObjs[i].transform.position + objDir.normalized;

            if (Vector3.Distance(this.transform.position, objPos) < dist)
            {
                chosenObj = objPos;
                dist = Vector3.Distance(this.transform.position, objPos);
            }
        }

        Seek(chosenObj);

    }
        
    public bool CanSeeTarget()
    {
        RaycastHit raycastInfo;
        Vector3 targetXZPos = new Vector3(target.transform.position.x, 0.7f, target.transform.position.z);
        Vector3 thisXZPos = new Vector3(transform.position.x, 0.7f, transform.position.z);
        Vector3 rayToTarget = targetXZPos - thisXZPos;
        // Debug.DrawRay(thisXZPos, rayToTarget, Color.magenta);
        if (Physics.Raycast(thisXZPos, rayToTarget, out raycastInfo))
        {
            if (raycastInfo.transform.gameObject.tag == "Player")
                return true;
        }
        return false;
    }

}
