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

    #endregion

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
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

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            rig.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }

    }



}