using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckStay : MonoBehaviour
{
    public Material gold;
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        // Destroy everything that leaves the trigger
        //this.GetComponent<Renderer>().material = gold;
        other.GetComponent<AutoMove>().stillSurvive = false;
        other.GetComponent<AutoMove>().Check();
    }

    void OnTriggerStay(Collider other)
    {
        // Destroy everything that leaves the trigger
        other.GetComponent<AutoMove>().stillSurvive = true;
        other.GetComponent<AutoMove>().Check();
    }
}
