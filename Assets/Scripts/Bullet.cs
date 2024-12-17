using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damageAmount = 25f;
    public float moveSpeed = 30f;
    public float lifeTime = 5.0f;
    
    void Start()
    {
        Destroy(gameObject, lifeTime); // Can be changed, with a Box collider at the top of the screen, just a temp solution
    }
    void Update()
    {
        transform.Translate(0.0f, 0.0f, moveSpeed * Time.deltaTime);
    }
    
}
