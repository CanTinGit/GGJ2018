using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

    public Material gold, origin;
    public GameObject dianguang;
    public List<GameObject> trail = new List<GameObject>();
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("End");
        
        other.GetComponent<AutoMove>().LightTrail(trail);
        other.GetComponent<AutoMove>().speed = 0;
        other.GetComponent<AutoMove>().isend = true;
        Destroy(dianguang);
        other.GetComponent<AudioSource>().Stop();
    }
}
