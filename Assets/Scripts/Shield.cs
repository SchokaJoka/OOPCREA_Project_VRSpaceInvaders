using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour, IDamageable
{
    private float tumble = 0.25f;
    [SerializeField]
    private Material material;
    [SerializeField]
    private int shieldLives = 10;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        material = GetComponentInChildren<MeshRenderer>().material;
        if (!material)
        {
            Debug.LogError("Shield.cs: material Not Found");
        }
    }


    private void ChangeMaterialColor(int lives)
    {
        switch (lives)
        {
            case 10:
            {
                material.color = Color.blue;
                break;
            }
            case 9:
            {
                material.color = Color.red;
                break;
            }
            case 8:
            {
                material.color = Color.green;
                break;
            }
            default:
            {
                material.color = Color.white;
                break;
            }
        }
    }
    public void OnHit()
    {
        shieldLives--;
        if (shieldLives == 0)
        {
            Destroy(gameObject);
        }

        ChangeMaterialColor(shieldLives);

    }
}