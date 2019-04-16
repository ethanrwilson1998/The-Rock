using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleMouseCameraMovement : MonoBehaviour
{
    [SerializeField] private DigitalCursor DC;
    private Image cursor;

    [SerializeField] private Vector3 bounds;
    private Vector3 start;

    [Range(0, 0.5f)]
    [SerializeField] private float xSens;
    [Range(0, 0.5f)]
    [SerializeField] private float ySens;

    [SerializeField] private float strength;

    [SerializeField] private bool isActive = true;
    private Vector3 reference;

    

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        cursor = DC.GetCursor();   
    }

    private void OnEnable()
    {
        Dialog.OnDialogueStart += DisableCameraMove;
        Dialog.OnDialogueEnd += EnableCameraMove;
    }

    private void OnDisable()
    {
        Dialog.OnDialogueStart -= DisableCameraMove;
        Dialog.OnDialogueEnd -= EnableCameraMove;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            float x = cursor.rectTransform.position.x / Screen.width - 0.5f;
            float y = cursor.rectTransform.position.y / Screen.height - 0.5f;

            Vector3 goal = start;

            if (Mathf.Abs(x) > xSens)
            {
                goal += 2 * x * Vector3.Scale(Vector3.left, bounds);
            }
            if (Mathf.Abs(y) > ySens)
            {
                goal += 2 * y * Vector3.Scale(Vector3.up, bounds);
            }

            transform.position = Vector3.SmoothDamp(transform.position, goal, ref reference, 5 / strength);
        }

    }

    public void DisableCameraMove()
    {
        isActive = false;
    }

    public void EnableCameraMove()
    {
        isActive = true;
    }
}
