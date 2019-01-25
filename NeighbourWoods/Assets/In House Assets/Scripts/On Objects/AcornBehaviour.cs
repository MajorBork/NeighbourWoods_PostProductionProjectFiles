using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.UI;

public class AcornBehaviour : MonoBehaviour
{
    public GameObject acorn;
    public UIManager uiManager;
    public string itemNameOnObject;
	void Start () // Use this for initialization
    {
		
	}
	void Update () // Update is called once per frame
    {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        acorn.SetActive(false);
        uiManager.SendMessage("UpdateItem", itemNameOnObject);
    }
}
