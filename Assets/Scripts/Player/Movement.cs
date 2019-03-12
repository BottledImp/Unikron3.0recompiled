using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    public float speed = 3f;
    public float jumpSpeed = 2f;
    public float crouchspeed = 1f;
    private Rigidbody2D rig;
    public float inputVector;
    public GameObject holder;
    private bool grounded;
    public BoxCollider2D Boxcollider;
    #endregion

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Run();
        Crouch();
        Jump();

    }

    

    private void Move()
    {

        inputVector = Input.GetAxis("Horizontal");

        if (inputVector != 0)
        {
            gameObject.transform.Translate(inputVector * speed * Time.deltaTime, 0, 0);
        }
        if (inputVector < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (inputVector > 0)
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
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (grounded)
            {
                Boxcollider.enabled = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
           Boxcollider.enabled = true;
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
    }

    private void Jump() {
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            rig.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }

    }



}