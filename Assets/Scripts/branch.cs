using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class branch : MonoBehaviour {

    int i = 1;
    void OnTriggerEnter(Collider other)
    {
        if (i == 1)
        {
            Vector3 initialPosition = new Vector3();
            initialPosition = other.transform.position + transform.forward * 3;
            // GameObject obj = Instantiate(other.gameObject,initialPosition,Quaternion.EulerAngles(other.transform.eulerAngles.x, other.transform.eulerAngles.y, other.transform.eulerAngles.z));
            GameObject obj = Instantiate(other.gameObject);
            obj.transform.position = initialPosition;
            obj.transform.eulerAngles = this.gameObject.GetComponent<Guider>().originAngles;
            i--;
        }
        
    }

   
}
