using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckIfActive : MonoBehaviour
{
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += CheckAtSceneStart;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= CheckAtSceneStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckAtSceneStart(Scene name, LoadSceneMode mode)
    {
        Debug.Log("check happened");
        if (FindObjectOfType<GameState>().allDialoguesComplete)
        {
            arrow.SetActive(true);
        }
    }
}
