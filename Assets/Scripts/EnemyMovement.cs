using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rigidBody;
    Animator    animator;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator  = GetComponent<Animator>();
    }

    void Update()
    {
        rigidBody.velocity = new Vector2 (moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other) 
    {
         moveSpeed = -moveSpeed;
         FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {

        transform.localScale = new Vector2(-(Mathf.Sign(rigidBody.velocity.x)), 1f);
        
    }
}
