using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    // Health Icon Array
    public GameObject[] healthObjects = new GameObject[3];
    public Material fullHealthMaterial;
    public Material emptyHealthMaterial;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Set the health icons to the current Lifes
    public void UpdateHealthDisplay(int playerHealth)
    {
        for (int i = 0; i < healthObjects.Length; i++)
        {
            if (i < playerHealth)
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
