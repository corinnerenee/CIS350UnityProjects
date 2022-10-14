using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScoreManager : MonoBehaviour
{
    //private GemBehaviour gemScript;
    public Text scoreText;
    public Text eofgText; //end of game text for win or lose
    public int score;
    public bool won;
    public bool gameOver;
    public float timeValue;

    // Start is called before the first frame update
    void Start()
    {
         // = GameObject.FindGameObjectWithTag("GemBehaviour").GetComponent<GemBehaviour>();
        scoreText.text = "Score: 0";
        won = false;
        gameOver = false;
        timeValue = 120;
    }

    private void Update()
    {
        float min = Mathf.FloorToInt(timeValue / 60);
        float sec = Mathf.FloorToInt(timeValue % 60);

        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime; 
        }

        if (timeValue >= 0 && score >= 10)
        {
            gameOver = true;
            won = true;
            eofgText.text = "You Won! Press A to Play Again!";
        }

        if( timeValue <= 0 && score < 10)
        {
            gameOver = true;
            won = false;
            eofgText.text = "You've ran out of time! Press A to Play Again";
        }
           
        
    }

    public void AddScore()
    {
        //to increment
        score++;

        scoreText.text = "Score: " + score;
    }
}
