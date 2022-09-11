using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text textbox;
    public int score = 0;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<Text>();
        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        while (!gameOver)
        {
            textbox.text = "Score: " + score;
        }
        if (score == 5)
        {

        }
    }
}
