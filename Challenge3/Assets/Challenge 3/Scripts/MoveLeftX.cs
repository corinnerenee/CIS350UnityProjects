using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed = 30f;
    private PlayerControllerX playerControllerScript;
    private float leftBound = -10;


    // Update is called once per frame
    void FixedUpdate()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();

        // If game is not over, move to the left
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
