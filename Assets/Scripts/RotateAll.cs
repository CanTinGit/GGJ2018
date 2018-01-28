using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAll : MonoBehaviour
{

    public GameObject obj;
    bool rotateDown, rotateUp, rotateLeft, rotateRight,rotateFor,rotateBack;
    float value = 0;
    bool isrotating;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rotateDown)
        {
            if ((value += 90 * Time.deltaTime) <= 90.2f)
            {
                transform.RotateAround(obj.transform.position, Vector3.right, 90 * Time.deltaTime);
                return;
            }
            rotateDown = false;
            isrotating = false;
        }

        if (rotateUp)
        {
            if ((value += 90 * Time.deltaTime) <= 90.2f)
            {
                transform.RotateAround(obj.transform.position, Vector3.right, -90 * Time.deltaTime);
                return;
            }
            rotateUp = false;
            isrotating = false;
        }

        if (rotateLeft)
        {
            if ((value += 90 * Time.deltaTime) <= 90.2f)
            {
                transform.RotateAround(obj.transform.position, Vector3.up, -90 * Time.deltaTime);
                return;
            }
            rotateLeft = false;
            isrotating = false;
        }

        if (rotateRight)
        {
            if ((value += 90 * Time.deltaTime) <= 90.2f)
            {
                transform.RotateAround(obj.transform.position, Vector3.up, 90 * Time.deltaTime);
                return;
            }
            rotateRight = false;
            isrotating = false;
        }

        if (rotateFor)
        {
            if ((value += 90 * Time.deltaTime) <= 90.2f)
            {
                transform.RotateAround(obj.transform.position, Vector3.forward, 90 * Time.deltaTime);
                return;
            }
            rotateFor = false;
            isrotating = false;
        }

        if (rotateBack)
        {
            if ((value += 90 * Time.deltaTime) <= 90.2f)
            {
                transform.RotateAround(obj.transform.position, Vector3.forward, -90 * Time.deltaTime);
                return;
            }
            rotateBack = false;
            isrotating = false;
        }
        // transform.RotateAround(obj.transform.position, Vector3.right, 20 * Time.deltaTime);
    }

    private IEnumerator horizontalRotate()
    {
        float value = 0;
        while ((value += 90 * Time.deltaTime) <= 90.2f)
        {
            transform.RotateAround(obj.transform.position, Vector3.right, 90 * Time.deltaTime);
            yield return null;
        }
    }

    public void RotateDown()
    {
        if (isrotating == false)
        {
            rotateDown = true;
            value = 0;
            isrotating = true;
        }
    }

    public void RotateUP()
    {
        if (isrotating == false)
        {
            rotateUp = true;
            value = 0;
            isrotating = true;
        }

    }

    public void RotateLeft()
    {
        if (isrotating == false)
        {
            rotateLeft = true;
            value = 0;
            isrotating = true;
        }

    }

    public void RotateRight()
    {
        if (isrotating == false)
        {
            rotateRight = true;
            value = 0;
            isrotating = true;
        }

    }

    public void RotateForward()
    {
        if (isrotating == false)
        {
            rotateFor = true;
            value = 0;
            isrotating = true;
        }

    }

    public void RotateBackward()
    {
        if (isrotating == false)
        {
            rotateBack = true;
            value = 0;
            isrotating = true;
        }

    }
}