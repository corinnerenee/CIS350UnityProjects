using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 5.0f;
    private float forwardInput;
    private float powerupStrength = 15.0f;

    public bool hasPowerUp;

    private GameObject focalPoint;
    public GameObject powerupIndicator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Player collided w/ " + collision.gameObject.name
                + " w/ powerup set to  " + hasPowerUp);

            //assign to enemys rigid boddy
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            //vector3 direction away from player
            Vector3 awayFromPlayer =
                (collision.gameObject.transform.position - transform.position).normalized;

            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
        //focalPoint = GameObject.Find("FocalPoint"); //searches thru all game objects which can be very slow
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        powerupIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);
    }

    private void FixedUpdate()
    {
        playerRB.AddForce(focalPoint.transform.forward * speed * Time.deltaTime);
        //playerRB.AddForce(Vector3.forward * speed * forwardInput);     
        //vector3 is a global direction, change to local coordinates based on cam view   
    }
}
