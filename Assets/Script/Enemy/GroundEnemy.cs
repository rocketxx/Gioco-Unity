using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GroundEnemy : Enemy
{
    /*
    protected override void Init()
    {
        //base.Init();
        Debug.Log("Init di ground enemy");
    }
    */
    /*
    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
    */

    protected override void Reset()
    {
        base.Reset();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }
}
