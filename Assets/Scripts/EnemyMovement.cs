using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float moveDistance = 1f;
    private float moveInterval = 1f;
   
    public float startDelay;
    private bool isAlive = true;
    
    public EnemyMovementTop enemyMovementTop;
    
    void Start()
    { 
        StartCoroutine(StartDelayRoutine());
    }
    
    private IEnumerator StartDelayRoutine()
    {
        yield return new WaitForSeconds(startDelay);
        StartCoroutine(MoveRoutine());
    }
    
    private IEnumerator MoveRoutine()
    {
        while (isAlive)
        {
            Move();
            yield return new WaitForSeconds(moveInterval);
        }
    }
    
    private void Move()
    {
        if (enemyMovementTop.movingRight)
        {
            transform.Translate(Vector2.right * moveDistance);
        }
        else
        {
            transform.Translate(Vector2.left * moveDistance);
        }
    }
}
