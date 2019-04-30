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

    public void EnableGameObject(GameObject o)
    {
        o.SetActive(true);
    }

    public void DisableCollider(Collider b)
    {
        b.enabled = false;
    }

    public void GoToLastScene()
    {
        string x = FindObjectOfType<GameState>().getLastScene();

        SceneManager.LoadScene(x);
    }

    public void PlayOutro()
    {
        FindObjectOfType<BGM>().PlayOutro();
        
    }

    public void PlayPiano()
    {
        FindObjectOfType<BGM>().PlayPiano();
    }

    public void PlayTense()
    {
        FindObjectOfType<BGM>().PlayTension();
        Debug.Log("Called");
    }

    public void ReturnToTitle()
    {
        GameState s = FindObjectOfType<GameState>();
        if (s != null)
        {
            Destroy(s.gameObject);
        }
        SceneManager.LoadScene("Title");
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
