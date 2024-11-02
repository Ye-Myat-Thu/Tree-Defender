using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public float bulletSpeed = 20f;
    public float lifeTime = 0.25f; //duration of bullet in the scene
    public int damage = 2;

    void Start()
    {
        rb.velocity = transform.right * bulletSpeed;

        Destroy(gameObject, lifeTime); 
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BearHealth bear = hitInfo.GetComponent<BearHealth>();
        if (bear != null)
        {
            bear.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
