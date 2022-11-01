using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#region This code makes the class a singleton
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    private string currentLevelName; //keep track of level we're on

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
#endregion 
//methods to load and unload scences
    public void LoadLevel(string levelName)
    {
        //load level in background instead of freezing/lag effect
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
         if (ao == null)
        {
            Debug.LogError("[GameManager]: Unable to load level");
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

}




