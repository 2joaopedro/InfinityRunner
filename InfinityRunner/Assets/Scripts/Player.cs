using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private bool isJumping;
    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim =  GetComponent<Animator>();
    }

    void FixedUpdate() // é chamado pela fisica da unity.
    {
        Movement();
        Jump();
    }
    void Movement()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJumping){
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
            isJumping = true;
        }
    }
    void OnCollisionEnter2D(Collision2D Collision){
        if(Collision.gameObject.layer == 8){
            isJumping = false;
            anim.SetBool("Jump",false);
        }
    }
}


   