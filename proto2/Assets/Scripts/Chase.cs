using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Chase : MonoBehaviour
{
    public NavMeshAgent enemy;

    void Update()
    {
        enemy.SetDestination(GameObject.FindWithTag("Player").transform.position);
    }
}
