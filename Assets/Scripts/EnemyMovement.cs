using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveDistance = 1f;
    public float moveDownDistance = 1f;
    public float moveInterval = 0.5f;
    
    private bool movingRight = true;
    
    void Start()
    {
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            Move();
            yield return new WaitForSeconds(moveInterval);
        }
    }
    
    void Move()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveDistance);
        }
        else
        {
            transform.Translate(Vector2.left * moveDistance);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            movingRight = !movingRight;
            transform.Translate(Vector3.back * moveDownDistance);
        }
    }
}
