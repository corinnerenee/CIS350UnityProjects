using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    public Text waveText;
    public Text eogText;

    public int enemyCount;
    public int waveNumber = 0;

    private bool won;
    private bool gameOver;
    private float spawnRange = 9;

    PlayerController pControl;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        Pause();

        SpawnEnemyWave(waveNumber);
        SpawnPowerup(1);
        pControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        waveText.text = "Current Wave: " + waveNumber;
        won = false;
        gameOver = false;
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

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i  < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length; //gets an array of all objects with tag
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Unpause();
        }
        if (enemyCount == 0) {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup(1);
        }

        if (pControl.transform.position.y < 0 && waveNumber != 10)
        {
            won = false;
            gameOver = true;
            eogText.text = "You Lose! Press R to Restart";
        }

        if(waveNumber >= 10)
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

    void SpawnPowerup(int powerupsToSpawn)
    {
        for(int i = 0; i < powerupsToSpawn; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(),
                powerupPrefab.transform.rotation);
        }
    }
    
}
