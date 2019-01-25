using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatBehaviour : MonoBehaviour
{
    private NavMeshAgent catAgent;
    public GameObject Player;
    public float playerDistanceRun = 4.0f; // the distance that the cat runs away from the player
	void Start () // Use this for initialization
    {
        catAgent = GetComponent<NavMeshAgent>();
	}
	void Update () // Update is called once per frame
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        //Debug.Log("Distance" + distance);
        if (distance < playerDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
            catAgent.SetDestination(newPos);
        }
	}
}
