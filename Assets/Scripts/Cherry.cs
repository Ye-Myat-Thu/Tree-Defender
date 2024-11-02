using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public Rigidbody2D cherryRb;
    public float speed = 2.5f;
    public float range = 1;
    private float timer;
    public int damage = 1;
    public float knockbackForce = 5;

    void FixedUpdate()
    {
        cherryRb.velocity = Vector2.right * speed;

        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<BearHealth>())
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * knockbackForce, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<BearHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

