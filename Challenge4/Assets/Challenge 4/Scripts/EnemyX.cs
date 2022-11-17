using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    public SpawnManagerX spawnMan;

    // Start is called before the first frame update
    void Start()
    {
        spawnMan = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");

    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
            //spawnMan.enemiesL++;
            
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            spawnMan.enemiesL++;
            Destroy(gameObject);
        }

    }

}
