using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public Rigidbody2D RB;
    public int moveSpeed;
    private float direction;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    public bool IsGround;
    public Transform GroundDetect;
    public LayerMask WhatIsGround;
    public int DoubleJump = 1;
    public Animator animator;
    public AudioSource somDopulo;


    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * (-1);
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Input.GetAxis("Horizontal")!= 0)
        {
            //is Running
            animator.SetBool("Running", true);
        }
        else
        {
            //is not runing
            animator.SetBool("Running", false);
        }

        IsGround = Physics2D.OverlapCircle(GroundDetect.position, 0.1f, WhatIsGround);

        if(Input.GetButtonDown("Jump") && IsGround)
        {
            RB.velocity = Vector2.up * 10;
            somDopulo.Play();
        }
        else if (Input.GetButtonDown("Jump") && !IsGround && DoubleJump > 0)
        {
            RB.velocity = Vector2.up * 8;
            DoubleJump--;
            somDopulo.Play();
        }
        if(IsGround)
        {
            DoubleJump = 1;
        }


        direction = Input.GetAxis("Horizontal");

         if( direction > 0)
        {
            // direita
            transform.localScale = facingRight;
        }

        else if ( direction < 0)
        {
            // esquerda
            transform.localScale = facingLeft;
        }

        RB.velocity = new Vector2 (direction * moveSpeed, RB.velocity.y);
    }
}
