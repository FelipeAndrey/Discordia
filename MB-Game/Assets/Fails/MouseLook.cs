using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    private Vector2 mouseLook;
    private float xRotation = 0f;


    [SerializeField] private Transform playerBody;

    private PlayerInput playerInput;


    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        mouseLook = playerInput.Player.Mouse.ReadValue<Vector2>();

        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(0, xRotation, 0);

        playerBody.Rotate(Vector3.up * mouseX);


    }

}
