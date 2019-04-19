using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;
    [SerializeField] private int numDialoguesLeft;

    


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        Dialog.ImportantDialogueComplete += DecrementDialoguesLeft;

    }

    private void OnDisable()
    {
        Dialog.ImportantDialogueComplete -= DecrementDialoguesLeft;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecrementDialoguesLeft()
    {
        numDialoguesLeft -= 1;
        if (numDialoguesLeft <= 0)
        {
            AllDialoguesComplete();
        }
    }

    public void AllDialoguesComplete()
    {
        Debug.Log("All dialogues have been complete");
        // Do stuff here
    }
}
