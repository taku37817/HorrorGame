using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navigation_enemy_move : MonoBehaviour
{
    [SerializeField]
    private Transform target = null;

    private NavMeshAgent agent = null;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            agent.destination = target.position;
        }
    }
}
