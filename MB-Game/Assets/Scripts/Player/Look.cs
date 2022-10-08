using UnityEngine;

public class Look : MonoBehaviour
{
    public float mouseSensitivity;
    public float xRotation = 0f;
    public float yRotation = 0f;
    public bool canLook { get; set; } = true;

    [SerializeField] Transform orientetion;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (canLook) 
        {
            CamereLook();
        }
    }

    private void CamereLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientetion.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
