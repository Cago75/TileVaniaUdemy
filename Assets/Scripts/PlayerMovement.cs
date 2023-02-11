using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rigidBody;
    [SerializeField] float velocity     = 10f;
    [SerializeField] float jumpSpeed    = 10f;
    [SerializeField] float climbSpeeds  = 10f;
                     float gravityScale = 7.98f;
    Animator animator;
    CapsuleCollider2D capsuleCollider;

    void Start()
    {
        rigidBody           = GetComponent<Rigidbody2D>();
        animator            = GetComponent<Animator>();
        capsuleCollider     = GetComponent<CapsuleCollider2D>();
        gravityScale        = rigidBody.gravityScale;
    }

    void Update()
    {
        Run();
        ClimbLadder();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Run()
    {
       
        Vector2 playerVelocity = new Vector2(moveInput.x * velocity, rigidBody.velocity.y);
        rigidBody.velocity = playerVelocity;

        bool playerHorizontalSpeed  = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon; 
        bool playerVerticalSpeed    = Mathf.Abs(rigidBody.velocity.y) > 0.1; 
        animator.SetBool("isJumping", (playerVerticalSpeed));
        animator.SetBool("isRunning", playerHorizontalSpeed&&!playerVerticalSpeed);        
    }
    void OnJump(InputValue value)
    {
        //bool playerVerticalSpeed = Mathf.Abs(rigidBody.velocity.y) > Mathf.Epsilon; 
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {return;}
        
        if(value.isPressed)
        { 
            rigidBody.velocity += new Vector2(0f, jumpSpeed);
              
        }
        animator.SetBool("isJumping", true); 
    }
    void ClimbLadder()
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rigidBody.gravityScale  = gravityScale;
            animator.SetBool("isClimbing", false); 
            return;
        }

        Vector2 ClimbVelocity   = new Vector2(rigidBody.velocity.x, moveInput.y * climbSpeeds);
        rigidBody.velocity      = ClimbVelocity;  
        rigidBody.gravityScale  = 0f;
        animator.SetBool("isClimbing", true); 


    }

    void FlipSprite()
    {
        bool playerHorizontalSpeed = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon; 
        if(playerHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
        } 
               
    }


}
