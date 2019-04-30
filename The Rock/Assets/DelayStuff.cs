using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayStuff : MonoBehaviour
{
    [SerializeField] private Collider casper;
    [SerializeField] private Dialog dialog;

    [SerializeField] private float time;


    // Start is called before the first frame update
    void Start()
    {
        casper.enabled = false;

        Invoke("TurnOn", time);
    }

    private void TurnOn()
    {
        casper.enabled = true;
        dialog.EnableDialogBox();
    }
}
