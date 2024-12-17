using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : EnemyArmy
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            TakeDamage(other.GetComponent<Bullet>().damageAmount);
            Destroy(other.gameObject);
        }
    }
}
