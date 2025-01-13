using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Variables
    public float moveSpeed = 30f;
    public float lifeTime = 5.0f;
    
    // Unity
    void Update()
    {
        transform.Translate(0.0f, 0.0f, moveSpeed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }
    
    // Collision Handling
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.OnHit();
            Destroy(gameObject);
        }
    }
}
