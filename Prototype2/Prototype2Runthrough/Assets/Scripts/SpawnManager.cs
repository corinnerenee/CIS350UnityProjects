using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //drag prefabs to spawn into array using inspector
    public GameObject[] prefabsToSpawn;

    //variables for spawn positon
    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20; //positon of spawning animals on z axis (top of screen)
    public bool gameOver = false;

    void Start()
    {
        //InvokeRepeating("SpawnRandomPrefab", 2, 1.5f); //2 second delay, repeats every 1.5 sec
        StartCoroutine(SpawnRandomPrefabWithCoroutine());
    }
    // Update is called once per frame
    /* void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //SpawnRandomPrefab();
           
        }
    }*/
    IEnumerator SpawnRandomPrefabWithCoroutine() //coroutine allows us to pause/continue
    {
        yield return new WaitForSeconds(3f); //3 Sec delay before animals spawn

        while (true)
        {
            SpawnRandomPrefab();
            float randomDelay = Random.Range(0.8f, 2.0f);
            yield return new WaitForSeconds(randomDelay); //1.5 sec between animals spawning
        }
    }

    void SpawnRandomPrefab()
    {
        //generate random index
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        //spawn randomly selected prefab
        Instantiate(prefabsToSpawn[prefabIndex], new Vector3(0, 0, 0), prefabsToSpawn[prefabIndex].transform.rotation);

        //generate spawn positon
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        //spawn animal
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);

    }
}
