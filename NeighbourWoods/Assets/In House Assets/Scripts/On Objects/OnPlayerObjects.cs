using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerObjects : Singleton<OnPlayerObjects>
{

    public List<GameObject> mouthObjects;
	// Use this for initialization
	void Start ()
    {
        DisableAll();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DisableAll()
    {
        foreach (GameObject go in mouthObjects)
        {
            go.SetActive(false);
        }
    }
    public void EnableItem(string item)
    {
        DisableAll();
        foreach (GameObject go in mouthObjects)
        {
            if (go.name==item)
            {
                
                go.SetActive(true);

            }
        }
    }
}
