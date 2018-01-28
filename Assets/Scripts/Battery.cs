using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

    public GameObject wire;
    public GameObject dianguang;
    public List<GameObject> batterys = new List<GameObject>();
    public AudioClip charge;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Change");
        wire.transform.eulerAngles = wire.transform.eulerAngles + new Vector3(0, 180, 0);
        other.GetComponent<AutoMove>().stillSurvive = true;
        dianguang.SetActive(false);
        other.GetComponent<AutoMove>().speed = 0;
        other.GetComponent<AutoMove>().setSpeed = -0.25f;
        other.transform.parent = transform;
        other.GetComponent<AudioSource>().Stop();
        other.GetComponent<AudioSource>().clip = charge;
        other.GetComponent<AudioSource>().PlayOneShot(charge);
        for (int i = 0; i < batterys.Count; i++)
        {
            batterys[i].SetActive(true);
        }
    }
}
