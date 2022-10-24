using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWRaycasts : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100;
    public float hitForce = 10f;

    public Camera cam;
    public ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")){ Shoot(); }
    }

    void Shoot()
    {
        //play at particle effect @ beginning of method
        muzzleFlash.Play();

        RaycastHit hitInfo;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.gameObject.name);
            
            //get target script from hit objct
            TargetHealth target =
                hitInfo.transform.gameObject.GetComponent<TargetHealth>();

            //if target script ws found
            if( target != null)
            {
                target.TakeDamage(damage);
            }

            //if shot hits rigidbody, apply force
            if(hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}
