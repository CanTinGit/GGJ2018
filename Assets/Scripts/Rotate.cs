using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public GameObject cube1, cube2;
    public float speed, horizontalSpeed, verticalSpeed;
    public bool isRotate,rotateRight,rotateLeft, rotateUp,rotateDown;
    Vector3 startPosition, endPosition, distance;
    float localy,localx;
    public int movedown = 0;
    int moveup = 0;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRotate = true;
            startPosition = Input.mousePosition;
            Debug.Log(startPosition);
        }
    }

    void Update()
    {
        if (isRotate == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                endPosition = Input.mousePosition;
                Debug.Log(endPosition);
                distance = endPosition - startPosition;
                Debug.Log(distance);
                if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
                {
                    Debug.Log("X>Y");
                    if (distance.x > 0)
                    {
                        localy = transform.eulerAngles.y;
                        if (localy == 0)
                        {
                            localy = 360;
                        }
                        Debug.Log(localy);
                        rotateRight = true;
                        // Vector3 middle = (cube1.transform.position + transform.position)/2;
                        //transform.RotateAround(middle, Vector3.up, 20 * Time.deltaTime);
                    }
                    else
                    {
                        Debug.Log("X>0");
                        localy = transform.eulerAngles.y;
                        rotateLeft = true;
                    }
                }
                else
                {
                    Debug.Log("X<Y");
                    if (distance.y < 0)
                    {
                        movedown++;
                        if (movedown == 0)
                        {
                            localx = 270;
                        }
                        if (movedown == 1)
                        {
                            localx = 0;
                        }
                        else if (movedown ==2)
                        {
                            localx = 90;
                        }
                        else if(movedown == 3){
                            localx = 360;
                        }
                        else if (movedown == 4)
                        {
                            localx = 270;
                            movedown = 0;
                        }
                        rotateDown = true;
                        Debug.Log(localx);
                    }
                    else
                    {
                            movedown = movedown - 1;
                        if (movedown == 0)
                        {
                            localx = 90;
                        }
                        if (movedown == -1)
                            {
                                localx = 360;
                            }
                            else if (movedown == -2)
                            {
                                localx = 270;
                            }
                            else if (movedown == -3)
                            {
                                localx = 0;
                            }
                            else if (movedown == -4)
                            {
                                localx = 90;
                                movedown = 0;
                            }
                        rotateUp = true;
                            Debug.Log(localx);
                    }
                }
                isRotate = false;
            }
        }

        //RotateLeft
        if (rotateLeft == true)
        {
            
            Vector3 middle = (cube1.transform.position + transform.position) / 2;
            transform.RotateAround(middle, Vector3.up, 50 * Time.deltaTime);
            cube1.transform.RotateAround(middle, Vector3.up, 50 * Time.deltaTime);
            //Debug.Log(transform.eulerAngles.y);
            float angles = localy + 90;
            if (angles == 360)
            {
                if (angles - transform.eulerAngles.y <1.0f)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    cube1.transform.eulerAngles = new Vector3(0, 0, 0);
                    rotateLeft = false;
                }
            }
           
            if (transform.eulerAngles.y >= angles)
            {
                Debug.Log(angles);
                transform.eulerAngles = new Vector3(0, angles, 0);
                cube1.transform.eulerAngles = new Vector3(0, angles, 0);
                rotateLeft = false;
            }
        }

        //RotateRight
        if (rotateRight == true)
        {
            Vector3 middle = (cube1.transform.position + transform.position) / 2;
            transform.RotateAround(middle, Vector3.up, -50 * Time.deltaTime);
            cube1.transform.RotateAround(middle, Vector3.up, -50 * Time.deltaTime);
            float angles = localy - 90;
            if (angles == 0)
            {
                if (transform.eulerAngles.y - angles < 1.0f)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    cube1.transform.eulerAngles = new Vector3(0, 0, 0);
                    rotateRight = false;
                }
            }
            //Debug.Log(angles);
            if (transform.eulerAngles.y <= angles)
            {
                transform.eulerAngles = new Vector3(0, angles, 0);
                cube1.transform.eulerAngles = new Vector3(0, angles, 0);
                rotateRight = false;
            }
        }

        if (rotateDown == true)
        {
            Vector3 middle1 = (cube2.transform.position + transform.position) / 2;
            transform.RotateAround(middle1, Vector3.left, -50 * Time.deltaTime);
            cube2.transform.RotateAround(middle1, Vector3.left, -50 * Time.deltaTime);
            Debug.Log(transform.eulerAngles.x);
           

            float angles = Mathf.Abs(transform.eulerAngles.x - localx);
            Debug.Log(angles);
            if (Mathf.Abs(angles - 90.0f) <= 1.2f)
            {
                rotateDown = false;
            }
        }

        if (rotateUp == true)
        {
            Vector3 middle1 = (cube2.transform.position + transform.position) / 2;
            transform.RotateAround(middle1, Vector3.left, 50 * Time.deltaTime);
            cube2.transform.RotateAround(middle1, Vector3.left, 50 * Time.deltaTime);
            Debug.Log(transform.eulerAngles.x);


            float angles = Mathf.Abs(transform.eulerAngles.x - localx);

            if (Mathf.Abs(angles - 90.0f) <= 1.2f)
            {
                rotateUp = false;
            }
        }
    }
}
