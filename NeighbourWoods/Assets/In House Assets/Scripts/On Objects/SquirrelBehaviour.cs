using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class SquirrelBehaviour : MonoBehaviour
{
    public GameObject animal;
    public Usable squirrelUsable;
    void Start() // Use this for initialization
    {
        squirrelUsable = GetComponent<Usable>();
    }
    void Update() // Update is called once per frame
    {

    }
    void RunAway()
    {
        StartCoroutine(DelayedRunAway());
    }
    IEnumerator DelayedRunAway()
    {
        yield return new WaitForSeconds(3);
        squirrelUsable.enabled = false;
        yield return new WaitForSeconds(3);
        animal.SetActive(false);
    }
}
