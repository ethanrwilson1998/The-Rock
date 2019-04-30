using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    [SerializeField] private AudioSource audio;

    public AudioClip piano;
    public AudioClip tenseBGM;
    public AudioClip outro;
    public AudioClip distortedIntro;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        audio = GetComponent<AudioSource>();
       
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += CheckScene;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= CheckScene;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckScene(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Casper's Room")
        {
            audio.loop = true;
            audio.clip = piano;
            audio.Play();
        }
        else if (scene.name == "Dream")
        {
            audio.clip = distortedIntro;
            audio.loop = false;
            audio.Play();
        }
        else if (scene.name == "TheRock")
        {
            audio.clip = tenseBGM;
            audio.loop = true;
            audio.Play();
        } else if (scene.name == "GameOver")
        {
            audio.clip = outro;
            audio.loop = false;
            audio.Play();
        }
    }

    public void PlayIntro()
    {
        audio.loop = false;
        audio.clip = distortedIntro;
        audio.enabled = false;
        audio.enabled = true;
        audio.Play();
    }

    public void PlayPiano()
    {
        audio.loop = true;
        audio.clip = piano;
        audio.enabled = false;
        audio.enabled = true;
        audio.Play();
    }

    public void PlayTension()
    {
        Debug.Log("Got here");
        audio.loop = true;
        audio.clip = tenseBGM;
        audio.enabled = false;
        audio.enabled = true;
        audio.Play();
    }

    public void PlayOutro()
    {
        Debug.Log("Got here");
        audio.loop = false;
        audio.clip = outro;
        audio.enabled = false;
        audio.enabled = true;
        audio.Play();
    }
}
