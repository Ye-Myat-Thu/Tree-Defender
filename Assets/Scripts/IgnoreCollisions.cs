using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{
    public BoxCollider2D playerCollider; // Assign in the Inspector
    public BoxCollider2D towerCollider;
    public BoxCollider2D ProjectileCollider;

    void Start()
    {
        // Ignore collisions between player and tower colliders
        Physics2D.IgnoreCollision(playerCollider, towerCollider);
        Physics2D.IgnoreCollision(ProjectileCollider, towerCollider);
    }
}
