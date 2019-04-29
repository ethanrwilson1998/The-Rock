using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogInstance : MonoBehaviour
{

    [SerializeField] private string speakerName;

    [SerializeField] private List<string> dialogues;
    private int index;

    [SerializeField] private List<Button> buttons;

    [SerializeField] private UnityEvent doOnFinish;

    private bool buttonsOn;

    private void Start()
    {
        DisableButtons();
    }

    public void Reset()
    {
        index = 0;
    }

    public string getNextDialog() {

        if (index >= dialogues.Count)
        {
            if (doOnFinish != null)
            {
                doOnFinish.Invoke();
            }
            return null;
        }

        string x = dialogues[index];
        index++;
        return x;
    }

    public string getSpeakerName() { return speakerName; }

    public void EnableButtons()
    {
        buttonsOn = true;
        foreach (Button b in buttons)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void DisableButtons()
    {
        buttonsOn = false;
        foreach (Button b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

    public bool ButtonsOn() { return buttonsOn; }
}
