using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;

    private float dirX = 0f;

    [SerializeField] private float moveSpeed=7f;
    [SerializeField] private float jumpForce=14f;

    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState {idle, walk, jump}
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if(Input.GetButtonDown("Jump") && isGrounded()){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        UpdateAnimationState();
        }

   private void UpdateAnimationState()
    {

        MovementState state;

        if (dirX > 0f) // moving right
        {
            sprite.flipX = true;
            anim.SetBool("walking", true);
            
        }
        else if (dirX < 0f) // moving left
        {
            sprite.flipX = false; // flips the character 180 degrees so he faces left when we're moving left
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    private bool isGrounded()
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); 
        }   

}
