using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleOscillate : MonoBehaviour
{
    [SerializeField] private bool useSin;
    [SerializeField] private Vector3 posOffset;
    [SerializeField] private float timeScale;

    private Vector3 start;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (useSin)
        {
            transform.position = start + posOffset * Mathf.Sin(Time.time * timeScale);
        }
        else
        {
            transform.position = start + posOffset * Mathf.Cos(Time.time * timeScale);
        }
    }
}
