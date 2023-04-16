using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public static float moveSpeed;

    private void Start()
    {
        moveSpeed = 7f;
    }
    IEnumerator MoveSC()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        yield return null;
    }

    private void Update()
    {
        StartCoroutine(MoveSC());
    }

}
