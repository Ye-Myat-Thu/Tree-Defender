using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f;

    private Animator anim;

    private Rigidbody2D rb;
    private bool isGrounded;
    public float moveInput;

    //Flip
    private bool isFacingRight = true; //added 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
        CheckGround();

        //Added flip function
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Move()
    { 
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //original logic
        ////flip player
        //if(moveInput > 0.01f)
        //    transform.localScale = Vector3.one;
        //else if(moveInput < -0.01f)
        //    transform.localScale = new Vector3(-1,1,1);

        //anim.SetBool("run", moveInput != 0);

        anim.SetBool("run-Animation", moveInput != 0);
    }

    void CheckGround()
    {
        // Cast a ray downwards to check if the player is grounded
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        isGrounded = hit.collider != null;
    }

    public bool canAttack()
    {
        return moveInput == 0;
    }

    private void Flip() //added function Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
