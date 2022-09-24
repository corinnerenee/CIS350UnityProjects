using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private float upperBound = 13;
    private float lowerBound = 1.2f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    public bool lowEnough;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        gameOver = false;
        lowEnough = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRb.transform.position.y > upperBound && !gameOver)
        {
            //keep balloon within bounds
            lowEnough = false;
            Debug.Log("too high to jump");
            playerRb.AddForce(Vector3.down * 200);
        }
        else
        {
            lowEnough = true;
            //playerRb.AddForce(Vector3.up * floatForce);
        }
    
        
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {

            if(playerRb.transform.position.y > 15 && !gameOver)
        {
                lowEnough = false;
                Debug.Log("too high to jump");
            }
        else
        {
                lowEnough = true;
                playerRb.AddForce(Vector3.up * floatForce);
                //player moves down just a bit
                playerRb.AddForce(Vector3.down * 50);
            }
        }
        //player moves down just a bit
        playerRb.AddForce(Vector3.down * 10);

        //if player reaches lowerBound balloon bounces back up
        if(playerRb.transform.position.y < lowerBound && !gameOver)
        {
            playerRb.AddForce(Vector3.up * 100);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        { 
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
