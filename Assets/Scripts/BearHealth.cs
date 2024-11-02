using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public BearMovement bearMovement;
    public LeftBearMovement leftBearMovement;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the enemy immediately if health reaches 0
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is a projectile
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Retrieve the damage from the projectile if it has a damage property
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.damage); // Use projectile's damage value
            }

            // Destroy the projectile after collision
            Destroy(collision.gameObject);
        }
    }
}