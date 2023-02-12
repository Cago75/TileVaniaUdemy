using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidBody;
    PlayerMovement player;
    float bulletVelocity = 20f;
    float xSpeed;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player    = FindObjectOfType<PlayerMovement>();
        xSpeed     = player.transform.localScale.x * bulletVelocity;
    }

    void Update()
    {
        rigidBody.velocity = new Vector2(xSpeed,0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }    
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(this.gameObject);
    }
}
