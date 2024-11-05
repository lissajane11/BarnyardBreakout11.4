using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables for movement
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    private bool isGrounded = true;

    // Components
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        // Get horizontal input
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Set the velocity for movement along the x-axis
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip sprite based on movement direction
        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;
    }

    void Jump()
    {
        // Jump when grounded and "Jump" button (usually spacebar) is pressed
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    // Detect when the player is grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}