using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guider : MonoBehaviour
{
    public GameObject guide;
    public Vector3 originAngles;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Change");
        other.GetComponent<AutoMove>().stillSurvive = true;
        originAngles = other.transform.eulerAngles;
        Debug.Log(guide.transform.eulerAngles);
        other.transform.eulerAngles = guide.transform.eulerAngles;
        
    }
}