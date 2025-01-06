using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementTop : MonoBehaviour
{
    private float moveDownDistance = 1f;
    public bool movingRight = true;
    
    public void MoveDown()
    {
        transform.Translate(Vector3.back * moveDownDistance);
        movingRight = !movingRight;
    }
}
