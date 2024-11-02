using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearMovement : MonoBehaviour
{
    public Rigidbody2D bearRb;
    public int speed;

    void FixedUpdate()
    {
        if (GetComponent<BearHealth>().health > 0) // Ensure movement only if alive
        {
            bearRb.velocity = Vector2.left * speed;
        }
        else
        {
            bearRb.velocity = Vector2.zero; // Stop movement when dead
        }
    }
}