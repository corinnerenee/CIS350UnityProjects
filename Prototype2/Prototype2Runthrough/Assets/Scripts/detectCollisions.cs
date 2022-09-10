using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to food projectile prefab

public class detectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject); //destroy animal 
        Destroy(gameObject); //destroy food
    }
}
