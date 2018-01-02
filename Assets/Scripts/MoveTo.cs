using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour
{

    public Transform goal;

    void Start()
    {
        goal = GameObject.Find("Target").transform;
        UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;
    }
}