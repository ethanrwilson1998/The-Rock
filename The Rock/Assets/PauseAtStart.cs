﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAtStart : MonoBehaviour
{
    [SerializeField] private float amount;

    public AudioSource source;

    void Awake()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(amount);
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(1.5f);
        source.Play();

    }

    
}
