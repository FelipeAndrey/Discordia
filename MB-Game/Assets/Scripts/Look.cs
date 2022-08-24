using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [Range(100f,1000f)]
    public float mouseSensitivity;

    public Transform playerBody;

    private float xRotation = 0f;
    private float yRotation = 0f;

    [SerializeField] Transform cam;
    [SerializeField] Transform orientetion;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        camereLook();
    }

    private void camereLook() 
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientetion.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        //playerBody.Rotate(Vector3.up * mouseX);

    } 
}
