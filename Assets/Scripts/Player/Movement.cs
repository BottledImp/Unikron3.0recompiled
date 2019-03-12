using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    public float speed = 3f;
    public float jumpSpeed = 2f;
    private Rigidbody2D rig;
    public float inputVector;
    public GameObject holder;
    private bool grounded;
    public float JumpForce = 400;

    #endregion

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();


    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rig.AddForce(new Vector2(rig.velocity.x, JumpForce));
        }

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


   


}