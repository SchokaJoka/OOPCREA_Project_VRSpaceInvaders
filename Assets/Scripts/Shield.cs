using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour, IDamageable
{
    private float tumble = 0.25f;
    [SerializeField]
    private Material material;
    [SerializeField]
    private int shieldLives = 10;
    
    [SerializeField]
    private Color fullHealthColor = Color.white; // Starting color at full health
    [SerializeField]
    private Color lowHealthColor = Color.red;  // Color when nearly destroyed

    private int maxShieldLives;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        material = GetComponentInChildren<MeshRenderer>().material;
        if (!material)
        {
            Debug.LogError("Shield.cs: material Not Found");
        }
        
        maxShieldLives = shieldLives;
        UpdateShieldColor();
    }

    private void UpdateShieldColor()
    {
        // Calculate the percentage of health remaining
        float healthPercentage = (float)shieldLives / maxShieldLives;
        
        // Lerp between the low health color and full health color based on remaining health
        Color newColor = Color.Lerp(lowHealthColor, fullHealthColor, healthPercentage);
        
        material.color = newColor;
    }

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
}