using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealth : MonoBehaviour
{
    public float health = 50f;
    ScoreManager scoreMan;

    public void TakeDamage(float amount)
    {
        scoreMan = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        scoreMan.AddScore();
        Destroy(gameObject);
    }

    
}