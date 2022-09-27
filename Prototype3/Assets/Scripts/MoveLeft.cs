using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -15;

    private PlayerController playerScript;
    // Update is called once per frame
    void FixedUpdate()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if(playerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        } //destroy obstacle if out of bounds to the left
    }
}
