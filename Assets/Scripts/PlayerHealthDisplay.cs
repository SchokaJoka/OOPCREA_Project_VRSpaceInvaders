using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    // Components, References
    public GameObject[] healthObjects = new GameObject[3];
    public Material fullHealthMaterial;
    public Material emptyHealthMaterial;
    
    // Unity
    void Start()
    {
        // Initializing References
        CheckComponents();
    }

    private void OnEnable()
    {
        PlayerShip.OnPlayerTookDamage += UpdateHealthDisplay;
    }

    private void OnDisable()
    {
        PlayerShip.OnPlayerTookDamage -= UpdateHealthDisplay;
    }

    // Methods
    public void UpdateHealthDisplay(int currentPlayerHealth)
    {
        for (int i = 0; i < healthObjects.Length; i++)
        {
            if (i < currentPlayerHealth)
            {
                healthObjects[i].GetComponent<Renderer>().material = fullHealthMaterial;
            }
            else
            {
                healthObjects[i].GetComponent<Renderer>().material = emptyHealthMaterial;
            }
        }
    }
    private void CheckComponents()
    {
        if (healthObjects == null)
        {
            Debug.LogError("PlayerHealthDisplay.cs: healthObjects not found!");
        }

        if (!fullHealthMaterial)
        {
            Debug.LogError("PlayerHealthDisplay.cs: fullHealthMaterial not found!");
        }
        
        if (!emptyHealthMaterial)
        {
            Debug.LogError("PlayerHealthDisplay.cs: emptyHealthMaterial not found!");
        }
    }
}
