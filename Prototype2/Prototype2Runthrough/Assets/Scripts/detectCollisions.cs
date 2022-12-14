using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to food projectile prefab

public class detectCollisions : MonoBehaviour
{
    private DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }
    private void OnTriggerEnter(Collider other)
    {
        displayScoreScript.score++;
        Destroy(other.gameObject); //destroy animal 
        Destroy(gameObject); //destroy food
    }
}
