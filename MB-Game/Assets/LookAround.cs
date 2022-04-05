using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    [Range(10, 1000)]
    public float mouseSensitive;
    public Transform playerBody;
    float xRotation = 0f;
    float ScreenHeight;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitive * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitive * Time.deltaTime;

        ScreenHeight = Screen.height / 2;


        //Delimitador de visão por angulação + metade da tela
        /*
        if (Input.mousePosition.y > ScreenHeight)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 0f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 0f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        */

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
