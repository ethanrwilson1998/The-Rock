using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAtStart : MonoBehaviour
{
    [SerializeField] private float amount;
    [SerializeField] private float sfxOffset;

    public AudioSource source;

    void Awake()
    {
        source.mute = true;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(amount);
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(sfxOffset);
        source.mute = false;
        source.Play();

    }

    
}
