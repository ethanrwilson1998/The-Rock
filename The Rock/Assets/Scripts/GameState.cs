using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameState Instance;
    [SerializeField] private int numDialoguesLeft;


    [SerializeField] private bool momComplete;
    [SerializeField] private bool teacherComplete;
    [SerializeField] private bool magistrateComplete;

    public bool allDialoguesComplete;

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
        //Dialog.ImportantDialogueComplete += DecrementDialoguesLeft;

    }

    private void OnDisable()
    {
        //Dialog.ImportantDialogueComplete -= DecrementDialoguesLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (momComplete && teacherComplete && magistrateComplete) {
            allDialoguesComplete = true;
        }
    }

    

    public void ImportantDialogueComplete(int index)
    {
        switch (index) {
            case (0):
                momComplete = true;
                break;
            case (1):
                teacherComplete = true;
                break;
            case (2):
                magistrateComplete = true;
                break;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public bool IsMomComplete()
    {
        return momComplete;
    }

    public bool IsTeacherComplete()
    {
        return teacherComplete;
    }

    public bool IsMagistrateComplete()
    {
        return magistrateComplete;
    }
}
