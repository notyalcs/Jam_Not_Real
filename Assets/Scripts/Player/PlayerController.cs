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

    void FixedUpdate()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(movement, 0, 0).normalized;
        
        if (direction.magnitude > 0.1f)
        {
            gameObject.transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
