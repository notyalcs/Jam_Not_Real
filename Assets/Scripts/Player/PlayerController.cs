using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpStrength = 500f;
    public float moveSpeed = 10f;

    public bool airborne = false;

    private bool _lookingRight = true;

    private void Update()
    {
        if (!airborne)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                airborne = true;
                rb.AddForce(0, jumpStrength, 0);
            }
        }

        airborne = rb.velocity.y != 0;
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        
        if (movement > 0) _lookingRight = true;
        else if (movement < 0) _lookingRight = false;
        
        Vector3 direction = new Vector3(Math.Abs(movement), 0, 0).normalized;
        
        if (direction.magnitude > 0.1f)
        {
            if (_lookingRight)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
