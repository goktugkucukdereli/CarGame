using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarScript : MonoBehaviour
{
    JointMotor2D jM;
    public WheelJoint2D[] wJ;
    Vector2 screenBound;
    float objWidth;
    public GameObject pedal, rear, front, block;
    public float speed;

    void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Star"))
        {
            Destroy(collision.gameObject);
            Debug.Log("YILDIZ KAZANDINIZ.");
        }

        if (collision.gameObject.name.Equals("flag"))
        {
            pedal.gameObject.SetActive(false);
            transform.GetChild(0).GetComponent<WheelJoint2D>().useMotor = true;
            transform.GetChild(1).GetComponent<WheelJoint2D>().useMotor = true;
        }

        if (collision.gameObject.name.Equals("Maps"))
        {
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.name.Equals("Point"))
        {
            speed = 0f;
            block.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        Vector2 viewPoint;
        viewPoint.x = screenBound.x + objWidth;

        if ((transform.position.x >= viewPoint.x))
        {
            SceneManager.LoadScene(1);
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
        rear.transform.Rotate(0f, 0f, speed * Time.deltaTime * -50f);
        front.transform.Rotate(0f, 0f, speed * Time.deltaTime * -50f);
    }
}
