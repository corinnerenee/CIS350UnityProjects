using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 Corinne Bond
 Prototype 1
 ScoreManager Script that updates score based on other scripts
 */
public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool won;
    public static int score;

    public Text textbox;
    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //if game isnt over, display score
        if (!gameOver)
        {
            textbox.text = "Score: " + score;
        }

        //win conditon: 3 or more points
        if (score >= 3)
        {
            won = true;
        }

        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You Win!\nPress R to Try Again!";
            }

            else
            {
                textbox.text = "You Lose!\nPress R to Try Again!";
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
