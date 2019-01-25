using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class LieaBehaviour : MonoBehaviour
{
    public GameObject animal;
    public Usable lieaUsable;
    void Start() // Use this for initialization
    {
        lieaUsable = GetComponent<Usable>();
    }
    void Update() // Update is called once per frame
    {

    }
    public void RunAway()
    {
        StartCoroutine(DelayRunAway());
        
    }
    public IEnumerator DelayRunAway()
    {
        yield return new WaitForSeconds(3);
        lieaUsable.enabled = false;
        yield return new WaitForSeconds(3);
        animal.SetActive(false);
    }
}
