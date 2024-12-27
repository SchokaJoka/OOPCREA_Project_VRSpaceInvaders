using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float moveDistance = 1f;
    private float moveDownDistance = 1f;
    private float moveInterval = 1f;
    public float startDelay;
    
    private bool movingRight = true;
    
    void Start()
    {
        StartCoroutine(StartDelayRoutine());
    }


    IEnumerator StartDelayRoutine()
    {
        yield return new WaitForSeconds(startDelay);
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

    public void OnWallHit()
    {
        transform.Translate(Vector3.back * moveDownDistance);
        movingRight = !movingRight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
}
