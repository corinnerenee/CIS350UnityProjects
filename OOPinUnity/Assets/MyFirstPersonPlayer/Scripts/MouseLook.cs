using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public GameObject player;
    private float verticalLookRotation = 0f;

    void Update()
    {
        //assigning mouse input to floats
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //rotate player object w/ horizontal mouse input
        player.transform.Rotate(Vector3.up * mouseX);

        //rotate camera around x axis
        verticalLookRotation -= mouseY;

        //clamp rotation so player doesn't over rotate
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        //apply rotation based on input
        transform.localRotation = Quaternion.Euler(verticalLookRotation, 0, 0);

    }

    //hides and locks cursor to center of the screen
    private void MouseOnApplication()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}