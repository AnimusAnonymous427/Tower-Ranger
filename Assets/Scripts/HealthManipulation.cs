using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManipulation : MonoBehaviour
{
    private float health;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
