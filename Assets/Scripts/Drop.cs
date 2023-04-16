using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    Vector2 startPos;
    public GameObject shadow;
    public bool select;
    public bool inRightPos;
    public GameObject place;
    public GameObject freePlace;
    Control controllerSc;

    void Start()
    {
        controllerSc = FindObjectOfType<Control>();
        startPos = transform.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, shadow.transform.position) < 3)
        {
            transform.position = shadow.transform.position;
        }
        if (Vector2.Distance(transform.position , shadow.transform.position) < 1)
        {
            if(!select && !inRightPos)
            {
                
                transform.position = shadow.transform.position;
                inRightPos = true;
                controllerSc.PieceCount();
                place.SetActive(true);
                Destroy(gameObject);
                shadow.SetActive(false);
                freePlace.SetActive(false);


            }
        }
        if(!select && !inRightPos)
        {
            transform.position = startPos;
        }
    }
}
