using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GasScript : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    JointMotor2D jM;

    public GameObject car;
    public GameObject frontWheel, backWheel;
    public WheelJoint2D[] wJ;
    
    public Sprite gasPedalDown, gasPedalUp;
    public GameObject All;
    public float moveSpeed;

    private bool _isCar;

    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = gasPedalDown;
        _isCar = true;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = gasPedalUp;
        _isCar = false;
    }

    void Start()
    {
        moveSpeed = 10f;
        float width = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position = ViewportHandler.Instance.BottomLeft +new Vector3(width,width,0);
        _isCar = false;
    }

    void Update()
    {
        wJ[0].motor = jM;
        wJ[1].motor = jM;

        if (_isCar == true)
        {
            jM.motorSpeed = 650f;
            jM.maxMotorTorque = 100;

            //float gasLerpTime = Mathf.Lerp(0f, jM.motorSpeed, Time.deltaTime / 0.5f);
            //jM.motorSpeed = gasLerpTime;

            All.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        else
        {
            float brakeLerpTime = Mathf.Lerp(jM.motorSpeed, 0f, Time.deltaTime / 0.5f);
            jM.motorSpeed = brakeLerpTime;
        }
    }
}
