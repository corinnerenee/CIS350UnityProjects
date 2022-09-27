using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public bool won;

    private PlayerControllerX playerScript;
    // Start is called before the first frame update
    void Start()
    {  
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<Text>();
        }
        if (playerScript == null)
        {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();
        }


        scoreText.text = "Score: 0";

    }

    // Update is called once per frame
    void Update()
    {
        if(!playerScript.gameOver)
        {
            scoreText.text = "Score: " + score;
        }
        if (score >= 15)
        {
            playerScript.gameOver = true;
            won = true;
            scoreText.text = "You Win\n Press A to Play Again!";
        }
        if(playerScript.gameOver & !won)
        {
            scoreText.text = "You Lose!\n Press A to Play Again!";
        }
       
        if (playerScript.gameOver && Input.GetKeyDown(KeyCode.A))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

    }


}
