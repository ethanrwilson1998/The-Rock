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
    void Start()
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
        if (audio.isPlaying == false && scene.name == "Casper's Room")
        {
            audio.loop = true;
            audio.clip = piano;
            audio.Play();
        }
    }

    public void PlayIntro()
    {
        audio.loop = false;
        audio.clip = distortedIntro;
        audio.Play();
    }

    public void PlayPiano()
    {
        audio.loop = true;
        audio.clip = piano;
        audio.Play();
    }

    public void PlayTension()
    {
        audio.loop = true;
        audio.clip = tenseBGM;
        audio.Play();
    }

    public void PlayOutro()
    {
        audio.loop = false;
        audio.clip = outro;
        audio.Play();
    }
}
