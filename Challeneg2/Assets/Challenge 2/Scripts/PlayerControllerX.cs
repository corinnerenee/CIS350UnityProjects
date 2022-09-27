using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && nextFire < Time.time)
        {
            nextFire = Time.time + fireRate; //would += work here?
         
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
