using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private DisplayText displayScript;
    private void Start()
    {
        displayScript = GameObject.FindGameObjectWithTag("Score").GetComponent<DisplayText>();
    }
    private void OnTriggerEnter(Collider other)
    {
        displayScript.score++;
        Destroy(gameObject);
    }
}
