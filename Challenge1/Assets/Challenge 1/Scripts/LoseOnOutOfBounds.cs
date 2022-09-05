using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnOutOfBounds : MonoBehaviour
{

    public GameObject plane;
    // Update is called once per frame
    void Update()
    {

        if(plane.transform.position.y > 80 || plane.transform.position.y < -51)
        {
            ScoreManager.gameOver = true;
        }
        
    }
}
