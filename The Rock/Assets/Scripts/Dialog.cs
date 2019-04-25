using System.Collections;
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

    private bool clicked;
    //[SerializeField] private bool importantDialogue;

    public delegate void LockCamera();
    public static event LockCamera OnDialogueStart;
    public static event LockCamera OnDialogueEnd;

    public delegate void ImportantDialogue();
    public static event ImportantDialogue ImportantDialogueComplete;

    private void Start()
    {
        Hide();
        instance = instances[index++];
    }

    // for looping backwards, resetting dialog after clicking the wrong button?
    public void ResetToFirstDialog()
    {
        TurnOffButtons();
        index = 0;
        instance = instances[index++];

        foreach(DialogInstance i in instances)
        {
            i.Reset();
        }
    }

    public void DisableThisDialog()
    {
        gameObject.SetActive(false);
    }



    private void LateUpdate()
    {
        if (clicked)
        {
            string t = instance.getNextDialog();

            if (t == "<choice>")
            {
                dialog.text = "";
                instance.EnableButtons();
            }
            else if (t == "<next>")
            {
                AdvanceDialog();
                EnableDialogBox();
                t = instance.getNextDialog();
                if (t == "<choice>")
                {
                    dialog.text = "";
                    instance.EnableButtons();
                }
                else
                {
                    dialog.text = t;
                }
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
        clicked = false;
    }

    public void EnableDialogBox()
    {
        Show();
        OnDialogueStart.Invoke();
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
        OnDialogueEnd.Invoke();
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetType() != typeof(Button))
                transform.GetChild(i).gameObject.SetActive(false);
        }
    }



    public void OnBoxClicked()
    {


        if (!instance.ButtonsOn())
            clicked = true;

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

    public void CorrectButtonChosen()
    {
        ImportantDialogueComplete.Invoke();
    }
}
