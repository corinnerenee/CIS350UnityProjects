using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 Corinne Bond
 Prototype 1
 Adds one point to score if player goes through one trigger zone
 */
public class TriggerZoneAddScoreOnce : MonoBehaviour
{
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ScoreManager.score++;
        }
    }
}
