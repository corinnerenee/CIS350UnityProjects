using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    //gravity variables
    public Vector3 velocity;
    public float gravity = -9.81f;
    public float gravityMultipler = 2f;
    //groundCheck variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float jumpHeight = 3f;

    void Awake()
    {
        gravity *= gravityMultipler;
    }

    // Update is called once per frame
    void Update()
    {
        //check if  player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f; //reset gravity velocity to a low number
        }

        //get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //jump code
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //add gravity to velocity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        
        
    }
}
