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
        if (audio.isPlaying == false && scene.name == "Town")
        {
            audio.clip = piano;
            audio.Play();
        }
    }
}
