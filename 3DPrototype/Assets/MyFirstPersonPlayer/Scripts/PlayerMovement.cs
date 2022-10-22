using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public Vector3 velocity;
    public float gravity = -9.81f;
    public float gravityMultipler = 2f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        gravity += gravityMultipler;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Add gravity to velocity
        velocity.y += gravity * Time.deltaTime;
          
        //Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(velocity * Time.deltaTime);
    }
}
