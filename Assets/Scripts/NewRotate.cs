using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRotate : MonoBehaviour
{
    public GameObject MagicCube;
    float rotateSpeed;

    GameObject cubeObject; //被点中的cube
    Vector3 normal; //点击点的法线
    Vector3 mouseStart; //鼠标点击的初始点
    Vector3 mouseRun; //鼠标拖动时的点
    Vector3 mouseCross; //叉乘结果
    Vector3 vecZhou; //魔方某层转动时的转动轴
    bool isRotate = false; //某层是否可转动
    bool isRun = false; //是否可拖动鼠标
    float t = 0; //转动时的递增值的临时变量
    Vector3[] vecPoint; //六个原始轴
    GameObject[] cubes; //保存所有标签为Cube物体的父物体

    void Start()
    {
        vecPoint = new Vector3[] { Vector3.right, Vector3.up, Vector3.forward, Vector3.left, Vector3.down, Vector3.back };
        cubes = GameObject.FindGameObjectsWithTag("Cube");
        isRun = true;
    }

    void Update()
    {
        //按下鼠标记录相关内容
        if (Input.GetMouseButtonDown(0) && isRun)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitStart;
            if (Physics.Raycast(ray.origin, ray.direction, out hitStart))
            {
                cubeObject = hitStart.transform.gameObject;
                normal = hitStart.normal;
                mouseStart = hitStart.point;
            }
        }
        //记录拖动方向，叉乘得到法线方向
        if (Input.GetMouseButton(0) && cubeObject != null)
        {
            Ray rayRun = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitRun;
            if (Physics.Raycast(rayRun.origin, rayRun.direction, out hitRun))
            {
                mouseRun = hitRun.point - mouseStart;
                if (mouseRun.sqrMagnitude > 0.2)
                {
                    mouseCross = Vector3.Cross(normal, mouseRun).normalized;
                    RotatePoint(mouseCross);
                    cubeObject = null;
                }
            }
        }
        //转动相应的层
        if (isRotate)
        {
            t += Time.deltaTime * rotateSpeed;
            Vector3 rotate = vecZhou * Mathf.Clamp01(t) * 90;
            transform.eulerAngles = rotate;
            if (t >= 1)
            {
                t = 0;
                foreach (GameObject cube in cubes)
                {
                    cube.transform.parent = MagicCube.transform;
                    cube.transform.localScale = Vector3.one;
                }
                transform.rotation = Quaternion.identity;
                isRotate = false;
                isRun = true;
            }
        }
    }

    //遍历六个轴找出要转动的轴
    void RotatePoint(Vector3 cross)
    {
        for (var i = 0; i < 6; i++)
        {
            Vector3 vec = vecPoint[i];
            var dot = Vector3.Dot(vec, cross);
            if (dot > 0.72 && dot <= 1)
            {
                vecZhou = vec;
                for (var j = 0; j < 3; j++)
                {
                    if (Mathf.Abs(vec[j]) == 1)
                    {
                        FindFather(j);
                    }
                }
            }
        }
    }

    //找出转动轴后将要转动的层添加到物体上，用物体的转动带动层转动
    void FindFather(int point)
    {
        var cubeObjecePoint = cubeObject.transform.position[point];
        foreach (GameObject cube in cubes)
        {
            var cubePoint = cube.transform.position[point];
            if (Mathf.Abs(cubePoint - cubeObjecePoint) < 0.1)
            {
                cube.transform.parent = gameObject.transform;
            }
        }
        isRun = false;
        isRotate = true;
    }
}