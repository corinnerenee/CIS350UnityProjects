using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Corinne Bond
 Prototype 1
 Controls player/vehicle movements on map
 */

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float forwardInput;
    public float horizontalInput;
    public float turnSpeed;

    // Update is called once per frame
    void Update()
    {
        //input manager
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        //forward movement w/ forward input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        //scaling by input & time.delta for time between frame, turnspeed is speed variable
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
    }
}
