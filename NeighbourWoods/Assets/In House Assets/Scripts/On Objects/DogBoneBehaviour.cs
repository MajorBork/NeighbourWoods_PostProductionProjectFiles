using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.Inventory;
using Manager.UI;
using PixelCrushers.DialogueSystem;

public class DogBoneBehaviour : MonoBehaviour
{
    public GameObject dogBoneObject;
    public UIManager uiManager;
    void Start () // Use this for initialization
    {
		
	}
	void Update () // Update is called once per frame
    {
		
	}
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.ShowAlert("Dig! There is a bone here!");
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Dig"))
            {
                uiManager.DogBoneUpdate();
                dogBoneObject.SetActive(false);
            }
        }
    }
}
