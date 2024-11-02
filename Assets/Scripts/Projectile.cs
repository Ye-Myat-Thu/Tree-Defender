using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Animator anim;
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    public float knockbackForce = 5;
    public int damage = 1;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
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
