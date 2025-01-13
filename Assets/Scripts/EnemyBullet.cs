using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Variables
    public float moveSpeed = 30f; 
    public float lifeTime = 5.0f;
    public Vector3 moveDirection = Vector3.forward; // Default direction is upwards
    
    // Unity
    void Start()
    {
        Destroy(gameObject, lifeTime); // Can be changed, with a Box collider at the top of the screen, just a temp solution
    }
    
    void Update()
    {
        transform.Translate(moveDirection * (Time.deltaTime * moveSpeed));
    }
    
    // Collision handling
    private void OnTriggerEnter(Collider other)
    {
        // Ignore collision with other enemies
        if (other.gameObject.CompareTag("Octopus") || other.gameObject.CompareTag("Crab") || other.gameObject.CompareTag("Squid"))
        {
            return;
        }
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            Destroy(gameObject);
            damageable.OnHit();
        }
    }
}