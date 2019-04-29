using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    [SerializeField] private MeshCollider collider;
    public GameObject momArrow;

    public bool isMom;
    public bool isTeacher;
    public bool isMagistrate;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<MeshCollider>();
    }

    private void Awake()
    {
        GameState gameState = FindObjectOfType<GameState>();
        if (isMom && gameState.IsMomComplete())
        {
            collider.enabled = false;
            momArrow.SetActive(true);
        } else if (isTeacher && gameState.IsTeacherComplete())
        {
            collider.enabled = false;
        } else if (isMagistrate && gameState.IsMagistrateComplete())
        {
            collider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
