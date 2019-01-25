using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SlidingDoorBehaviour : MonoBehaviour
{
    public Animator slidingDoor;
    public BoxCollider sildingDoorCollider;
	// Use this for initialization
	void Start ()
    {
        sildingDoorCollider = GetComponent<BoxCollider>();
        slidingDoor.SetBool("Door Closed", true);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            slidingDoor.SetBool("Door Open", true);
            slidingDoor.SetBool("Door Closed", false);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            slidingDoor.SetBool("Door Open", true);
            slidingDoor.SetBool("Door Closed", false);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            slidingDoor.SetBool("Door Open", false);
            slidingDoor.SetBool("Door Closed", true);
        }
    }
}
