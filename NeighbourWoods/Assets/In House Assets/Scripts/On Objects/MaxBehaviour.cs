using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class MaxBehaviour : MonoBehaviour
{
    public GameObject animal;
    public BoxCollider maxCollider;
    public Usable maxUsable;
	void Start () // Use this for initialization
    {
        maxCollider = GetComponent<BoxCollider>();
        maxUsable = GetComponent<Usable>();
	}
	void Update () // Update is called once per frame
    {
		
	}
    public void RunAway()
    {
        StartCoroutine(DelayedRunAway());
        maxUsable.enabled = false;
    }
    IEnumerator DelayedRunAway()
    {
        yield return new WaitForSeconds(5);
        animal.SetActive(false);
    }
}
