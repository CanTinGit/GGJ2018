using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AND : MonoBehaviour {
    public List<GameObject> trail = new List<GameObject>();
    int i = 0;
    public GameObject[] dians;
    void OnTriggerEnter(Collider other)
    {
        i++;
        other.GetComponent<AutoMove>().isend = true;
        if (i==2)
        {
            dians = GameObject.FindGameObjectsWithTag("Dian");
            for (int i = 0; i < dians.Length; i++)
            {
                Destroy(dians[i]);
            }
            other.GetComponent<AutoMove>().LightTrail(trail);
            other.GetComponent<AutoMove>().speed = 0;
            
        }
    }
}
