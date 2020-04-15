using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowTargetThr : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 destination;
    private NavMeshAgent agent;
    float rotateSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(destination,target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }

        //adjust the rotation of the enermy, make it always faces to the player
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                                Quaternion.LookRotation(target.position - transform.position)
                                                , rotateSpeed * Time.deltaTime);



    }
}
