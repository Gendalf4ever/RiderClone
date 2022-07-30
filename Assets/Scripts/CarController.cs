using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    bool isPressed = false;
    bool isGrounded = false;
    public Rigidbody2D rb;
    public float speed = 40f;
    public float rotationSpeed = 2f;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isPressed = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isPressed = false;
        }
    }

    private void FixedUpdate()
    {
       if (isPressed == true)
        {
            if (isGrounded)
            {
                rb.AddForce(transform.right * speed * Time.fixedDeltaTime * 100, ForceMode2D.Force);
            }
            else
            {
                rb.AddTorque(rotationSpeed * rotationSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
