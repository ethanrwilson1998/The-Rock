using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float amount;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, amount * Time.deltaTime);
    }
}
