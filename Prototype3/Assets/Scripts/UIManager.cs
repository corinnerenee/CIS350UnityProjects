using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public bool won = false;

    private PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        if(scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }
        if(playerScript == null)
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }  
        if(score >= 10)
        {
            playerScript.gameOver = true;
            won = true;
            //playerScript.StopRunning();

            scoreText.text = "You Win\n Press A to Play Again!";
        }
        if(playerScript.gameOver && !won)
        {
            scoreText.text = "You Lose!\n Press A to Play Again!";
        }

        if(playerScript.gameOver && Input.GetKeyDown(KeyCode.A))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}
