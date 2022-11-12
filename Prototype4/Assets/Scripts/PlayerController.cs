using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 5.0f;
    private float forwardInput;

    private GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
        //focalPoint = GameObject.Find("FocalPoint"); //searches thru all game objects which can be very slow
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        playerRB.AddForce(focalPoint.transform.forward * speed * Time.deltaTime);
        //playerRB.AddForce(Vector3.forward * speed * forwardInput);     
        //vector3 is a global direction, change to local coordinates based on cam view   
    }
}
