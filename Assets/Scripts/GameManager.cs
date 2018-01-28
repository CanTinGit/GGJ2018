using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject gm = new GameObject("GM");
                gm.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    public bool isShooting = false;
    public int Level;

    public void LoadLevelNext()
    {
        StartCoroutine(WaitToLoadLevel());
    }
    IEnumerator WaitToLoadLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(GameManager.Instance.Level + 1);
    }
}
