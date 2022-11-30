using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(setDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManager.StartGame();
    }
}
