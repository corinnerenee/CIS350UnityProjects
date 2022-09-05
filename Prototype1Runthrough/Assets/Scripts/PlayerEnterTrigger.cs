using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//attach to player
/*
 Corinne Bond
 Prototype 1
 Checks to see if player is inside of trigger zone
 */

public class PlayerEnterTrigger : MonoBehaviour
{
    //set tris reference in the inspector
    public Text textbox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            ScoreManager.score++;
        }
     
    }
}
