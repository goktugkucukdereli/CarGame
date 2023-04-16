using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    private Vector2 screenBound;
    private float objWidth;
    public GameObject point;
    void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    void Update()
    {
        Vector3 viewPoint;
        viewPoint.x = screenBound.x + objWidth;

        if ((transform.position.x >= viewPoint.x) || (transform.position.x <= -viewPoint.x))
        {
            transform.position = point.transform.position;
        }
    }
}
