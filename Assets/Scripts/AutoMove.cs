using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoMove : MonoBehaviour {

    public float speed;
    public bool stillSurvive;
    public List<GameObject> trail = new List<GameObject>();
    public Material gold,origin;
    public bool isend = false;
    public bool buldLight;
    public GameObject dianguang;
    public float setSpeed = 0.25f;
	// Update is called once per frame
	void Update ()
    {
        transform.position = transform.position + -transform.forward * speed;
        if (stillSurvive == false)
        {
            StartCoroutine(Wait());
        }
        if (buldLight == true)
        {
            bulb.GetComponent<SpriteRenderer>().material = gold;
            GameManager.Instance.LoadLevelNext();
        }
	}

    public void Shoot()
    {
        transform.parent = null;
        speed = setSpeed;
        dianguang.SetActive(true);
    }


    public void Restart()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }

    public void Check()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        if (stillSurvive == false && isend == false)
        {
            Debug.Log("FAil");
            SceneManager.LoadScene(Application.loadedLevel);
        }
    }



    public void AddToTrail(GameObject obj)
    {
        trail.Add(obj);
    }

    public void LightTrail(List<GameObject> trail)
    {
        StartCoroutine(LightTrailIE(trail));
    }

    public GameObject bulb;
    IEnumerator LightTrailIE(List<GameObject> trail)
    {
        for (int i = 0; i < trail.Count; i++)
        {
            trail[i].GetComponent<Renderer>().material = gold;
            if (i >= trail.Count-1)
            {
                buldLight = true;
            }
            yield return new WaitForSeconds(0.05f);
        }

        
    }

    //IEnumerator LightBulb()
    //{
    //    for (int i = 6; i > 0; i--)
    //    {
    //        if (gameObject.GetComponent<Renderer>().material == gold)
    //        {
    //            bulb.GetComponent<Renderer>().material = origin;
    //        }
    //        else
    //        {
    //            bulb.GetComponent<Renderer>().material = gold;
    //        }

    //        yield return new WaitForSeconds(0.25f);
    //    }
    //}
}
