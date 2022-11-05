using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    public GameObject pauseMenu;
    public int score;
    private string currentLevelName = string.Empty; //keep track of level we're on
/*#region This code makes the class a singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //make sure game manager persists across scences
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); //if theres already an instance of the game manager
            Debug.Log("Trying to instantiate a second instance of singleton manager");
        }
    }
#endregion*/

//methods to load and unload scences
    public void LoadLevel(string levelName)
    {
        //load level in background instead of freezing/lag effect
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
         if (ao == null)
        {
            Debug.LogError("[GameManager]: Unable to load level" + levelName);
            return;
        }

        currentLevelName = levelName;
    }

    public void UnloadLevel(string levelName)
    {
        //load level in background instead of freezing/lag effect
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        {
            Debug.LogError("[GameManager]: Unable to load level");
            return;
        }
    }

    //methods for pausing and unpausing
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }

    }

    public void UnloadCurrentLevel()
    {
        //load level in background instead of freezing/lag effect
        AsyncOperation ao = SceneManager.UnloadSceneAsync(currentLevelName);
        {
            Debug.LogError("[GameManager]: Unable to load level" + currentLevelName);
            return;
        }
    }

}




