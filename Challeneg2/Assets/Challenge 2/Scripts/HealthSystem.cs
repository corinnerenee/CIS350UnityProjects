//This script is based on https://www.youtube.com/watch?v=3uyolYVsiWc
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public bool gameOver = false;
    public Text hSystem;
    public GameObject gameOverText;
    private void Start()
    {
        hSystem.text = "Health: " + maxHealth;
        maxHealth = 10;
        health = maxHealth; 
      
    }
    void Update()
    {
        hSystem.text = "Health: " + health;
        //If health is somehow more than max health, set health to max health
        if (health > maxHealth)
        {
            health = maxHealth;
        }
   
        if (health <= 0)
        {
            gameOver = true;
            gameOverText.SetActive(true);
            //Press R to restart if game is over
            if (Input.GetKeyDown(KeyCode.A))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }
    public void TakeDamage()
    {
        health--;
    }
    public void AddMaxHealth()
    {
        maxHealth++;
    }
}