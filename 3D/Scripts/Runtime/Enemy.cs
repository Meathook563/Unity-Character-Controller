using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 50.0f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}

