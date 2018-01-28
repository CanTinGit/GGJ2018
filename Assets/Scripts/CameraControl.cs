using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject aim;

    public float turnSpeed = 100.0f;      


    private Vector3 mouseOrigin;  
    private bool isRotating;   

    void Update()
    {
        // Get the left mouse button
        if (Input.GetMouseButtonDown(1))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }


        // Disable movements on button release
        if (!Input.GetMouseButton(1)) isRotating = false;

        // Rotate camera along X and Y axis
        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(aim.transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(aim.transform.position, Vector3.up, pos.x * turnSpeed);
        }
    }
}
