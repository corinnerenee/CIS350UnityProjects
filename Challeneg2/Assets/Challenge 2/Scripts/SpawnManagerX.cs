using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 3.0f;
    private float spawnInterval = 4.5f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, Random.Range(startDelay,spawnInterval));
        StartCoroutine(SpawnPrefabWRandomCoroutine());
    }

    // Spawn random ball at random x position at top of play area
    /*void SpawnRandomBall ()
    {
        //random int for diff colored balls
        int randomBall = Random.Range(0, ballPrefabs.Length);
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomBall], spawnPos, ballPrefabs[randomBall].transform.rotation);
    }*/

    IEnumerator SpawnPrefabWRandomCoroutine()
    {
        yield return new WaitForSeconds(4.0f);

        while (true)
        {
            SpawnRandomPrefab();
            float rDelay = Random.Range(3.0f, 5.0f);
            yield return new WaitForSeconds(rDelay);
        }
    }

    void SpawnRandomPrefab()
    {
        //generate random index
        int prefabIndex = Random.Range(0, ballPrefabs.Length);

        //spawn random colored ball
        Instantiate(ballPrefabs[prefabIndex], new Vector3(0, 0, 0), ballPrefabs[prefabIndex].transform.rotation);

        //random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), 0, spawnPosY);

        //spawn ball
        Instantiate(ballPrefabs[prefabIndex], spawnPos, ballPrefabs[prefabIndex].transform.rotation);


    }
}
