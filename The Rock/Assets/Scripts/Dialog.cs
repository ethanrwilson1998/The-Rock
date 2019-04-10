﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private Text title;
    [SerializeField] private Text dialog;

    // instances are stored as child gameobjects of this one, it scrolls through them, pausing for button interactions
    private DialogInstance instance;

    [SerializeField] private List<DialogInstance> instances;
    private int index;

    private void Start()
    {
        Hide();
        instance = instances[index++];
    }

    public void EnableDialogBox()
    {
        Show();
        title.text = instance.getSpeakerName();
        instance.DisableButtons();
        OnBoxClicked();
    
    }

    public void Show()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // buttons are controlled by instance
            if (transform.GetChild(i).GetType() != typeof(Button))
                transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetType() != typeof(Button))
                transform.GetChild(i).gameObject.SetActive(false);
        }
    }



    public void OnBoxClicked()
    {
        Debug.Log("Box clicked");

        string t = instance.getNextDialog();

        if (t == "<choice>")
        {
            dialog.text = "";
            instance.EnableButtons();
        }
        else if (t == null)
        {
            Hide();
            instance.Reset();
        }
        else
        {
            dialog.text = t;
        }

    }

    public void AdvanceDialog()
    {

        TurnOffButtons();
        if (index < instances.Count)
        {
            instance = instances[index++];
            Hide();
        }
        else
        {
            Debug.Log("fail : no more dialog");
        }
    }

    public void TurnOffButtons()
    {
        instance.DisableButtons();
        Hide();
    }


}