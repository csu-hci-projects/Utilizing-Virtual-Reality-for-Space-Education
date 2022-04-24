using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVRMove : MonoBehaviour
{
    public CharacterController controller;

    public Transform groundCheck;
    public LayerMask groundMask;


    [SerializeField] float speed = 10f;
    [SerializeField] float gravity = -9.81f;

    private Vector3 velocity;
    private bool isGrounded;
    private float groundDistance = 0.4f;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Movement();
        Gravity();

    }

    void Movement()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(xMove, 0f, zMove);

        controller.Move(move * speed * Time.deltaTime);
    }

    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
