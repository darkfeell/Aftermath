using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NavMesh : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out agent);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
    
    
}
