using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public GameObject selectedObject;
    Vector2 vec;
 
   
    void Update()
    {
        if(Input.touchCount > 0)
        {
            if(selectedObject != null && !selectedObject.GetComponent<Drop>().inRightPos)
            {
                selectedObject.transform.position = new Vector2(vec.x, vec.y);
            }

            var touch = Input.GetTouch(0);
            vec = Camera.main.ScreenToWorldPoint(touch.position);

            RaycastHit2D ray2d = Physics2D.Raycast(vec, Vector2.zero);

            if(ray2d.collider != null && selectedObject == null && (ray2d.collider.gameObject.name.Equals("Ucgen") || ray2d.collider.gameObject.name.Equals("Dikdortgen") ||
                ray2d.collider.gameObject.name.Equals("Daire") || ray2d.collider.gameObject.name.Equals("Kare") || ray2d.collider.gameObject.name.Equals("Altigen") ||
                ray2d.collider.gameObject.name.Equals("Silindir")))
            {
                selectedObject = ray2d.transform.gameObject;
            }

            if(selectedObject != null)
            {
                if(touch.phase == TouchPhase.Moved && !selectedObject.GetComponent<Drop>().inRightPos)
                {
                    selectedObject.GetComponent<Drop>().select = true;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled && selectedObject !=null)
                {
                    selectedObject.GetComponent<Drop>().select = false;
                    selectedObject = null;
                }
            }
        }
    }
}
