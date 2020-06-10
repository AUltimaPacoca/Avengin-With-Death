using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player5 : MonoBehaviour
{
    public Camera cam;
    private Vector3 velocity, rotation, camRotation, jumpHeight;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocity = Vector3.zero;
        jumpHeight = Vector3.zero;
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void camRotate(Vector3 _camRotation)
    {
        camRotation = _camRotation;
    }

    public void Jump(float _jumpHeight)
    {
        jumpHeight = new Vector3(0f, _jumpHeight, 0f);

    }

    private void FixedUpdate()
    {
        playRotation();
        playMovement();
    }

    void playRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null)
        {
            cam.transform.Rotate(-camRotation);
        }
    }

    void playMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        if(jumpHeight != Vector3.zero)
        {
            rb.MovePosition(rb.position + jumpHeight * Time.fixedDeltaTime);
            jumpHeight = Vector3.zero;
        }
    }
}
