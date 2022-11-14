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

    private enum MovementType { idle, walk}
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        coll=GetComponent<BoxCollider2D>();
        sprite=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX=Input.GetAxisRaw("Horizontal");
        rb.velocity=new Vector2(dirX * moveSpeed, rb.velocity.y);
        if(Input.GetButtonDown("Jump")){
            rb.velocity=new Vector2(rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
        }

   private void UpdateAnimationState()
    {

        MovementType state;

        if (dirX > 0f) // moving right
        {
            state = MovementType.walk;
            sprite.flipX = true;
            anim.SetBool("MovementType", true);
            
        }
        else if (dirX < 0f) // moving left
        {
            state = MovementType.walk;
            sprite.flipX = false; // flips the character 180 degrees so he faces left when we're moving left
            anim.SetBool("MovementType", true);
        }
        else
        {
            state = MovementType.idle; // after this the idle animation starts playing
            anim.SetBool("MovementType", false);
        }

    }
}
