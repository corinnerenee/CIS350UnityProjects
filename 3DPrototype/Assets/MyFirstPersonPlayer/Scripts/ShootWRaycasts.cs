using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWRaycasts : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100;
    public Camera cam;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")){ Shoot(); }
    }

    void Shoot()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.gameObject.name);
        }
    }
}
