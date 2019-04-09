using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAwayFromCursor : MonoBehaviour
{
    [SerializeField] private float speed;

    Vector3 heading;
    public GameObject cursor;

    private float myWidth;
    private float myHeight;

    private bool restrictX;
    private bool restrictY;
        

    public RectTransform ParentRT;
    private RectTransform MyRect;
    // Start is called before the first frame update
    void Start()
    {
        MyRect = GetComponent<RectTransform>();
        myWidth = (MyRect.rect.width + 5) / 2;
        myHeight = (MyRect.rect.height + 5) / 2;
    }

    // Update is called once per frame
    void Update()
    {


        heading = transform.position - cursor.transform.position;

        if ((transform.localPosition.x < 0 - ((ParentRT.rect.width / 2) - myWidth) && heading.x < 0) || (transform.localPosition.x > ((ParentRT.rect.width / 2) - myWidth) && heading.x > 0))
            restrictX = true;
        else
            restrictX = false;

        if ((transform.localPosition.y < 0 - ((ParentRT.rect.height / 2) - myHeight) && heading.y < 0) || (transform.localPosition.y > ((ParentRT.rect.height / 2) - myHeight) && heading.y > 0))
            restrictY = true;
        else
            restrictY = false;

        if (restrictX)
        {
            heading -= new Vector3(heading.x, 0f, 0f);
        }
        if (restrictY)
        {
            heading -= new Vector3(0f, heading.y, 0f);
        }


        transform.position += heading.normalized * speed;
    }
}
