using System.Collections;
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
    public float Playerhealth = 100f;
    

    
    public bool isCrouching;
    public bool isSliding;
    private bool grounded;
      


    private Rigidbody2D rig;
    public GameObject holder;
    public BoxCollider2D Boxcollider;
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
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            movespeed = 0;
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            movespeed = speed;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            movespeed = 0;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(movespeed * crouchspeed, GetComponent<Rigidbody2D>().velocity.y);

        if (movespeed < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movespeed > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Ground")) {
            grounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.collider.CompareTag("Ground")) {
            grounded = false;
        }
        
    }

    private void Crouch()
    {
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (grounded)
            {
                Boxcollider.enabled = false;
                isCrouching = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Boxcollider.enabled = true;
            isCrouching = false;
        }

        if (isCrouching && !isSliding)
        {
            crouchspeed = 0.5f;
        }
        else if (!isCrouching && !isSliding)
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
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S))
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }
    }



    private void Jump() {
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            rig.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);

        }
         

    }



}