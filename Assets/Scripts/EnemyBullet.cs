using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Variables
    public float moveSpeed = 30f; 
    public float lifeTime = 5.0f;
    public Vector3 moveDirection = Vector3.forward; // Default direction is upwards
    
    // Components, References
    public ScoreDisplay scoreDisplay;
    
    // Unity
    void Start()
    {
        Destroy(gameObject, lifeTime); // Can be changed, with a Box collider at the top of the screen, just a temp solution
        
        if (!scoreDisplay)
        {
            scoreDisplay = FindObjectOfType<ScoreDisplay>();
            if (!scoreDisplay)
            {
                Debug.LogError("EnemyBullet.cs: scoreDisplay Not Found");
            }
        }
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