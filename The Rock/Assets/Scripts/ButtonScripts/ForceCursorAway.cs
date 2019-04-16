using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCursorAway : MonoBehaviour
{
    [SerializeField]
    private float speed;
    //Determines if the cursor is pushed away or towards the button
    public bool away;

    public GameObject digitalCursor;
    Vector3 heading;
    // Start is called before the first frame update
    void Start()
    {
        if (digitalCursor == null) {
            digitalCursor = FindObjectOfType<DigitalCursor>().gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (away)
        {
            heading = digitalCursor.transform.position - transform.position;
        } else
        {
            heading = transform.position - digitalCursor.transform.position;
        }

        if (!away && heading.magnitude > 10f)
        {
            digitalCursor.transform.position = Vector3.LerpUnclamped(digitalCursor.transform.position,
                digitalCursor.transform.position + heading.normalized, (250f / heading.magnitude) * speed);
        }
    }
}
