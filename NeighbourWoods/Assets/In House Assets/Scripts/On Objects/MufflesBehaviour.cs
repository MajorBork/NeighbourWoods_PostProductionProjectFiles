using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.UI;

public class MufflesBehaviour : MonoBehaviour
{
    public GameObject animal;
    void Start () // Use this for initialization
    {

    }
	void Update () // Update is called once per frame
    {

    }
    void RunAway()
    {
        StartCoroutine(DelayedRunAway());
    }
    IEnumerator DelayedRunAway()
    {
        yield return new WaitForSeconds(5);
        animal.SetActive(false);
    }
}
