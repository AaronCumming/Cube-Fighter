using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;


public class EnemyPathfinding : MonoBehaviour
{

public Transform goal;

        void Update () {
          NavMeshAgent agent = GetComponent<NavMeshAgent>();
          agent.destination = goal.position;
        }

}