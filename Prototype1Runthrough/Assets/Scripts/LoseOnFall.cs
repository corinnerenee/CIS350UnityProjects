using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Corinne Bond
 Prototype 1
 This script checks player positon, if player falls off map they lose
 */

public class LoseOnFall : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //check loss condition
        if (transform.position.y < -1)
        {
            ScoreManager.gameOver = true;
        }
    }
}
