using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundScript : MonoBehaviour
{
    private void Start()
    {
        float objwidth = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position = ViewportHandler.Instance.MiddleLeft + new Vector3(objwidth, 0, 0);
    }
}
