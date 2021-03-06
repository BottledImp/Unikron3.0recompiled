﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Floats
    public float speed = 3f;
    float movespeed = 0f;
    public float jumpSpeed = 2f;
    public float crouchspeed = 1f;
    public float inputVector;

    #endregion

    #region Bools
    public bool Crouching;
    public bool Sliding;
    public bool Jumping;
    public bool Falling;
    public bool Running;
    public bool grounded;
    public bool Walking;

    
    #endregion

    #region Misc
    private Rigidbody2D rig;
    public GameObject holder;
    public BoxCollider2D Boxcollider;
    public Animator playeramanager;
    #endregion


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Move();
        Crouch();
        Run();
        Jump();
    }




    private void Move()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            movespeed = -speed;
            Walking = true;


        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            movespeed = 0;
            Walking = false;

        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            movespeed = speed;
            Walking = true;

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            movespeed = 0;
            Walking = false;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed * crouchspeed, GetComponent<Rigidbody2D>().velocity.y);

        if (movespeed < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            playeramanager.SetBool("isWalking", true);
        }
        else if (movespeed > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            playeramanager.SetBool("isWalking", true);
        }

        if (movespeed == 0)
        {
            playeramanager.SetBool("isWalking", false);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
            Falling = false;
            playeramanager.SetBool("isGrounded", true);
        }

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = false;
            playeramanager.SetBool("isGrounded", false);
        }

    }


    private void Crouch()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (grounded)
            {
                Boxcollider.enabled = false;
                Crouching = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            Boxcollider.enabled = true;
            Crouching = false;
        }

        if (Running && Crouching)
        {
            Sliding = true;
        }
        else if (Running && (Crouching || !Crouching))
        {
            Sliding = false;
        }

        if (Crouching && !Sliding)
        {
            crouchspeed = 0.5f;
        }
        else if ((!Crouching && !Sliding) || (Crouching && Sliding))
        {
            crouchspeed = 1f;
        }
    }


    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (grounded)
            {
                speed = speed * 2;
                Running = true;
                playeramanager.SetBool("isRunning", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 2;
            Running = false;
            playeramanager.SetBool("isRunning", false);
        }

    }


    private void Jump() {

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rig.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }

        if (rig.velocity.y > 2f && !grounded)
        {
            Jumping = true;
            Falling = false;
            playeramanager.SetBool("isJumping", true);
        }
        else if (rig.velocity.y < -2f && !grounded)
        {
            Jumping = false;
            Falling = true;
            playeramanager.SetBool("Jumping", false);
            playeramanager.SetBool("isFalling", true);
        }
    }



}