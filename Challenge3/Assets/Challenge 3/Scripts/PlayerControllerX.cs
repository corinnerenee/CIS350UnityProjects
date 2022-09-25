using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    

    public float floatForce;
    private float gravityModifier = 1.5f;
    public int score;
    private float upperBound = 13;
    private float lowerBound = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    public bool lowEnough;
    public bool gameOver;

    PlayerControllerX playerControl;
    UIManager ui;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        playerRb = GetComponent<Rigidbody>();
       ui =  GameObject.FindGameObjectWithTag("Score").GetComponent<UIManager>();
    

        if (playerControl == null)
        {
            playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();
        }

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        lowEnough = true;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRb.transform.position.y > upperBound && !playerControl.gameOver)
        {
            lowEnough = false;
            playerRb.AddForce(Vector3.down * 75);
            Debug.Log("too high to jump");
        }
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !playerControl.gameOver)
        {
                lowEnough = true;
                playerRb.AddForce(Vector3.up * floatForce);
                //player moves down just a bit
                playerRb.AddForce(Vector3.down * 75);
            
        }
    
        //if player reaches lowerBound balloon bounces back up
        if(playerRb.transform.position.y < lowerBound && !playerControl.gameOver)
        {
            playerRb.AddForce(Vector3.up * 100);
        }

        playerRb.AddForce(Vector3.down * 80);

      
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if player collides with bomb, explode and set gameOver to true

        if (collision.gameObject.CompareTag("Bomb"))
        { 
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            Debug.Log("Game Over!");
            Destroy(gameObject);
            playerControl.gameOver = true;
        } 

        // if player collides with money, fireworks
        else if (collision.gameObject.CompareTag("Money") && playerControl)
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            //Destroy(other.gameObject);
            ui.score++; //increment score

        }

    }

}
