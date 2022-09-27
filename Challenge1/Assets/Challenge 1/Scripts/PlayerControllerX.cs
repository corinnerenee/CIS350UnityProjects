using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float hRotationSpeed;
    public float verticalInput; 
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = speed * 4;
        hRotationSpeed = speed * 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        //changing movement to forward and multiplying by 5 to slow speed
        transform.Translate(Vector3.forward * speed * Time.deltaTime * 2); 
        
        // tilt the plane up/down based on up/down arrow keys
        // added verticalInput so its based on up/down arrows
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
    }
}
