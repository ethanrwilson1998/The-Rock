using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DigitalCursor : MonoBehaviour
{
    Image cursor;
    public float xsensitivity;
    public float ysensitivity;

    EventSystem eventSystem;
    GraphicRaycaster raycaster;
    PointerEventData pointerEventData;


    // Start is called before the first frame update
    void Start()
    {
        cursor = GetComponent<Image>();
        Cursor.lockState = CursorLockMode.Locked;
        raycaster = GetComponentInParent<GraphicRaycaster>();
        eventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Mouse X") != 0)
        {
            cursor.transform.position = cursor.transform.position + new Vector3(Input.GetAxis("Mouse X") * xsensitivity, 0f, 0f);
            
        }
        if (Input.GetAxis("Mouse Y") != 0)
        {
            cursor.transform.position = cursor.transform.position + new Vector3(0f, Input.GetAxis("Mouse Y") * ysensitivity, 0f);
           
        }

        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    private void HandleMouseClick()
    {
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = transform.position;

        List<RaycastResult> results = new List<RaycastResult>();

        raycaster.Raycast(pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<Button>())
            {
                ExecuteEvents.Execute(result.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
            }
        }
    }

    public void TestButton()
    {
        Debug.Log("Button clicked");
    }

    public Image GetCursor()
    {
        return GetComponent<Image>();
    }
}
