using System.Collections;
using UnityEngine;

public class EnemyRowMovement : MonoBehaviour
{
    // Variables
    public float startDelay;

    private float moveDistance = 1f;
    private float moveInterval = 1f;
    private float moveDownDistance = 1f;
    
    private bool isAlive = true;
    private bool directionRightTemp;
    private bool movingRight;
    
    // Unity
    void Start()
    { 
        StartCoroutine(TempValueRoutine());
        StartCoroutine(StartDelayRoutine());
    }

    // IEnumerator
    private IEnumerator TempValueRoutine()
    {
        while (isAlive)
        {
            directionRightTemp = movingRight;
            yield return new WaitForSeconds(moveInterval);
        }
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
    
    // Methods
    private void Move()
    {
        if (directionRightTemp)
        {
            transform.Translate(Vector2.right * moveDistance);
        }
        else
        {
            transform.Translate(Vector2.left * moveDistance);
        }
    }
    public void MoveDown()
    {
        transform.Translate(Vector3.back * moveDownDistance);
        movingRight = !movingRight;
    }
}
