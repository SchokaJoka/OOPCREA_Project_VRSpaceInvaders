using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    // Health Icon Array
    public GameObject[] healthObjects = new GameObject[3];
    public Material fullHealthMaterial;
    public Material emptyHealthMaterial;
    
    public PlayerShip playerShip;

    
    
    // Start is called before the first frame update
    void Start()
    {
        playerShip = FindObjectOfType<PlayerShip>();
        if (!playerShip)
        {
            Debug.LogError("PlayerHealthDisplay.cs: PlayerShip Not Found");
        }
    }

    // Set the health icons to the current Lifes
    public void UpdateHealthDisplay()
    {
        for (int i = 0; i < healthObjects.Length; i++)
        {
            if (i < playerShip.GetCurrentPlayerLifes())
            {
                healthObjects[i].GetComponent<Renderer>().material = fullHealthMaterial;
            }
            else
            {
                healthObjects[i].GetComponent<Renderer>().material = emptyHealthMaterial;
            }
        }
    }
}
