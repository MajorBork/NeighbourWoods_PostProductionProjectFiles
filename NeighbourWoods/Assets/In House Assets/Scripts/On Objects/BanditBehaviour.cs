using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class BanditBehaviour : MonoBehaviour
{
    public GameObject animal;
    public GameObject animal1;
    public GameObject animal2;
    public GameObject animal3;
    public GameObject animal4;
    public GameObject animal5;
    public Usable BanditUsable;
    public MaxBehaviour maxBehaviour; 
    void Start() // Use this for initialization
    {

    }
    void Update() // Update is called once per frame
    {

    }
    void RunAway()
    {
        StartCoroutine(DelayedRunAway());
        BanditUsable.enabled = false;
    }
    IEnumerator DelayedRunAway()
    {
        yield return new WaitForSeconds(6);
        maxBehaviour.maxCollider.enabled = true;
        animal.SetActive(false);
        animal1.SetActive(false);
        animal2.SetActive(false);
        animal3.SetActive(false);
        animal4.SetActive(false);
        animal5.SetActive(false);
    }
}
