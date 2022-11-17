using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int waveCount;

    public Text waveText;
    public Text eogText;

    private bool won;
    private bool gameOver;

    SpawnManagerX spawnMan;
    // Start is called before the first frame update
    void Start()
    {
        spawnMan = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
        eogText.text = "Survive 10 waves without letting all enemies hit the goal!";
        Pause();
        waveCount = 1;
        
        waveText.text = "Current Wave: " + waveCount;
        won = false;
        gameOver = false;

    }

    // Update is called once per frame
    void Update()
    {
        waveText.text = "Current Wave: " + (spawnMan.waveCount-1);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Unpause();
        }
        if(waveCount == 1 && spawnMan.enemiesL == 1)
        {
            gameOver = true;

            eogText.text = "You've Lost! Press R to Play Again";

        }
        if(waveCount - 1 == spawnMan.enemiesL && waveCount != 1)
        {
            gameOver = true;
            won = false;
            eogText.text = "You've Lost! Press R to Play Again";
        }
        if(gameOver == true)
        {
            Pause();
        }

        if (waveCount >= 10)
        {
            won = true;
            gameOver = true;
            eogText.text = "You've Won! Press R to Play Again!";
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        if (won && Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }


    }

    public void Pause()
    {
        Time.timeScale = 0f;
        eogText.text = "Survive 10 waves to win! Press the spacebar to begin";
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        eogText.text = " ";
    }
}
