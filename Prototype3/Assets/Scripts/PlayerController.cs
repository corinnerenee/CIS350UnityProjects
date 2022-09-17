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

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    private Animator playAnimator;
    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody
        rb = GetComponent<Rigidbody>();

        //get animator
        playAnimator = GetComponent<Animator>();

        //start running animation on start
        playAnimator.SetFloat("speed_f", 1.0f);

        //Modify gravity
        //Physics.gravity *= gravityModifer;
        if(Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifer;
        }
        forceMode = ForceMode.Impulse;
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            //stop dirt particle when player jumps
            dirtParticle.Stop();
            rb.AddForce(Vector3.up * jumpForce, forceMode);
            isOnGround = false;
            playAnimator.SetTrigger("Jump_trig");
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground") && !gameOver)
        {
            isOnGround = true;
            //start dirt particle again
            dirtParticle.Play();
        }else if(collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            //Debug.Log("Game Over!");
            gameOver = true;
            //play death animation
            playAnimator.SetBool("Death_b", true);
            playAnimator.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
        }

    }
}
