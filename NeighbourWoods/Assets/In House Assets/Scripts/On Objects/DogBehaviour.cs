using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogBehaviour : MonoBehaviour
{
    private NavMeshAgent dogAgent;
    private GameObject dog;
    public GameObject Player;
    public float dogChaseRange = 4.0f; // the distance that the dog chases you
    public float dogStopRange = 2.0f; // the distance that the dog stops
    void Start() // Use this for initialization
    {
        dogAgent = GetComponent<NavMeshAgent>();
    }
    void Update() // Update is called once per frame
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        //Debug.Log("Distance" + distance);
        if (distance <= dogChaseRange)
        {
            dogAgent.SetDestination(Player.transform.position);
            dogAgent.stoppingDistance = dogStopRange;
        }
    }
}
