using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : MonoBehaviour
{
    [Tooltip("The GameObject variable that is the player object in the scene")]
    public Transform player;
    public float carNoticeRange = 10f;
    public Transform pathHolder;
    public GameObject[] waypoints;
    public float wpAccuracy = 0f;
    public int currentWP = 0;
    private Vector3 direction;
    private float angle;
    public float carSpeed = 1.5f;
    public float carRotation = 0.1f;
    void Start() // Use this for initialization
    {
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            waypoints[i] = new Vector3(waypoints[i].x, transform.position.y, waypoints[i].z);
        }
    }
    void Update() // Update is called once per frame
    {
        angle = Vector3.Angle(direction, this.transform.forward); // The angle
        direction.y = 0;
        if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < wpAccuracy)
        {
            currentWP++;
            if (currentWP >= waypoints.Length) // restarts the waypoint array if the currentWP is greater than the elements of the array
            {
                currentWP = 0;
            }
        }
        direction = waypoints[currentWP].transform.position - transform.position;
        direction.y = 0;
        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), carRotation * Time.deltaTime);
        this.transform.Translate(0, 0, Time.deltaTime * carSpeed);
    }
    void OnDrawGizmos() // draws the spheres in the editors so we have a better idea of the path of the demon
    {
        Vector3 startPosition = pathHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;
        foreach (Transform waypoint in pathHolder)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);
        Gizmos.DrawRay(transform.position, transform.forward * carNoticeRange);
    }
}
