using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool won;
    public static int score;

    public Text textbox;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        won = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            textbox.text = "Score: " + score;
        }
        if ( score >= 5)
        {
            won = true;
        }

        if (gameOver)
        {
            if (won)
            {
                textbox.text = "You Win!\nPress Z to Play Again!";
            }
            else
            {
                textbox.text = "You Lost!\nPress Z to Play Again!";
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
