using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAway : MonoBehaviour
{
    public int numTeleports;
    public GameObject cursor;

    private float myWidth;
    private float myHeight;
    private float trueWidth;
    private float trueHeight;

    public RectTransform ParentRT;
    private RectTransform MyRect;

    // Start is called before the first frame update
    void Start()
    {
        MyRect = GetComponent<RectTransform>();
        myWidth = (MyRect.rect.width + 5) / 2;
        myHeight = (MyRect.rect.height + 5) / 2;
        
        if (cursor == null)
        {
            cursor = FindObjectOfType<DigitalCursor>().gameObject;
        }
        if (ParentRT == null)
        {
            ParentRT = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        }

        trueWidth = (ParentRT.rect.width / 2) - myWidth;
        trueHeight = (ParentRT.rect.height / 2) - myHeight;
        Debug.Log(trueWidth);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToCursor = Vector3.Distance(transform.position, cursor.transform.position);

        if (distanceToCursor < 15f)
        {
            HandleTeleport();
        }
    }

    private void HandleTeleport()
    {
        if (numTeleports > 0)
        {
            numTeleports -= 1;

            transform.localPosition = new Vector3(Random.Range(-trueWidth, trueWidth), Random.Range(-trueHeight, trueHeight), 0f);

        }
    }
}
