using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ScoreManager : MonoBehaviour
{
    public Text Score;
    public Text eogText; //end of game text

    public bool won;
    public bool gameOver;

    public int score;
    public int max;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        won = false;
        gameOver = false;
        score = 0;
        Score.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Score: " + score;
        Debug.Log(score);

        if (score == max)
        {
            won = true;
            eogText.text = "You've Won! \n Press Z To Play Again!";
        }
        if (gameOver && score != max)
        {
            eogText.text = "Oh no, You've Ran out of Time! \n Press Z to Try Again!";
        }

        if (gameOver && Input.GetKeyDown(KeyCode.Z))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        if (won && Input.GetKeyDown(KeyCode.Z))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

    }
    public void AddScore()
    {
        score++;
    }

}