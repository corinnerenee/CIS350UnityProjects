using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Corinne Bond
 Prototype 1
 Takes relative player positon and adds an offset
 */

public class CamFollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -10);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
            //assigning 3d space for camera + offset
    }
}
