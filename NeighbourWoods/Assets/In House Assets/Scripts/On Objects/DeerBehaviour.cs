using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerBehaviour : MonoBehaviour
{
    public GameObject deer;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void DeerMove()
    {
        deer.SetActive(false); // to be changed to move the deer
    }
}
