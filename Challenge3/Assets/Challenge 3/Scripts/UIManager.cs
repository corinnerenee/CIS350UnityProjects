using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int score;
    public Text scoreKeeper;

    public PlayerControllerX playerScript;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Text>();
        scoreKeeper.text = "Score: 0";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
