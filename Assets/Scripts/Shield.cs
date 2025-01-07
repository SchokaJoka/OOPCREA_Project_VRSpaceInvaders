using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour, IDamageable
{
    // Variables
    private float tumble = 0.25f;
    private int shieldLives = 10;
    private int maxShieldLives;
    
    [SerializeField]
    private Color fullHealthColor = Color.white; // Starting color at full health
    [SerializeField]
    private Color lowHealthColor = Color.red;  // Color when nearly destroyed
    
    // Components, References
    [SerializeField]
    private Material material;
    private Rigidbody rigidBody;

    // Unity
    void Start()
    {
        // Initializing References, Components
        CheckComponents(); 
        
        maxShieldLives = shieldLives;
        AnimateObject();
        UpdateShieldColor();
    }
    
    // IDamageable Interface
    public void OnHit()
    {
        shieldLives--;
        if (shieldLives <= 0)
        {
            Destroy(gameObject);
            return;
        }
        UpdateShieldColor();
    }

    // Methods
    private void UpdateShieldColor()
    {
        float healthPercentage = (float)shieldLives / maxShieldLives;
        Color newColor = Color.Lerp(lowHealthColor, fullHealthColor, healthPercentage);
        material.color = newColor;
    }
    private void AnimateObject()
    { 
        rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
    }
    private void CheckComponents()
    {
        if (!rigidBody)
        {
            rigidBody = GetComponent<Rigidbody>();
            if (!rigidBody) Debug.LogError("Shield.cs: rigidBody not found!");
        }
        if (!material)
        {
            material = GetComponentInChildren<MeshRenderer>().material;
            if (!material) Debug.LogError("Shield.cs: material not found!");
        }
    }
}