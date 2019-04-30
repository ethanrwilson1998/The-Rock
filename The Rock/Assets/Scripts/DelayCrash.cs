using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayCrash : MonoBehaviour
{
    private AudioSource source;

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(Delaying());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Delaying()
    {
        yield return new WaitForSecondsRealtime(time);
        source.Play();
    }
}
