using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIUtility : MonoBehaviour
{
    public void ChangeScene(string x)
    {
        SceneManager.LoadScene(x);
    }

    public void ChangeScene(int x)
    {
        SceneManager.LoadScene(x);
    }
}
