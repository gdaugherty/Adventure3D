using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonNav : MonoBehaviour
{
    private DragonAI dragonAI;
    
    // Start is called before the first frame update
    void Start()
    {
        dragonAI = GetComponent<DragonAI>();
    }



    // Update is called once per frame
    void Update()
    {
        if (dragonAI.CanSeeTarget())
        {
            dragonAI.Pursue();
        }
        else
        {
            dragonAI.Protect();
        }
    }
}
