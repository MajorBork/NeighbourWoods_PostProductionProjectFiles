using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscarBehaviour : MonoBehaviour
{
    public GameObject Gate1;
    public GameObject Gate2;
	
	void Start () // Use this for initialization
    {
		
	}
	void Update () // Update is called once per frame
    {
		
	}
    void OpenGate()
    {
        Gate1.SetActive(false);
        Gate2.SetActive(false);
    }
}
