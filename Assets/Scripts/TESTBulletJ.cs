using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TESTBulletJ : MonoBehaviour
{

    public float moveSpeed = 30f; 
    public Vector3 moveDirection = Vector3.forward; // Default direction is upwards
    public float lifeTime = 5.0f;
    
    public ScoreDisplay scoreDisplay;
    
    void Start()
    {
        Destroy(gameObject, lifeTime); // Can be changed, with a Box collider at the top of the screen, just a temp solution
        
        if (!scoreDisplay)
        {
            scoreDisplay = FindObjectOfType<ScoreDisplay>();
            if (!scoreDisplay)
            {
                Debug.LogError("TESTBulletJ.cs: scoreDisplay Not Found");
            }
        }
    }
    void Update()
    {
        transform.Translate(Time.deltaTime * moveDirection * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with " + other.gameObject.name);
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            // Debug.Log("Found IDamageable in " + other.gameObject.name);
            damageable.OnHit();
        }
    }
}