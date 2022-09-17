using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public ForceMode forceMode;
    public float gravityModifer;

    public bool isOnGround = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody
        rb = GetComponent<Rigidbody>();

        //Modify gravity
        Physics.gravity *= gravityModifer;

        forceMode = ForceMode.Impulse;
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
        }else if(collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over!");
        }

    }
}
