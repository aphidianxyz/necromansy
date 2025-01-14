using System;
using Unity.Mathematics;
using UnityEngine;

public class unitStats : MonoBehaviour
{
    public float health = 30f;
    public bool isAlive = true;
    public float damage = 5f;
    public float attackRange = 4f;
    public float timeBetweenAttacks = 2f;

    public GameObject projectile = null;
    public bool isRanged = false;

    public float moveSpeed = 2f;

    public float cost = 2f;
    public float bloodLevel = 0f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        gameObject.GetComponents<CircleCollider2D>()[1].radius = attackRange;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (health <= 0 || !isAlive)
        {
            Die();
        }
        
    }

    public void TakeDamage(float damageDelt)
    {
        health -= damageDelt;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

