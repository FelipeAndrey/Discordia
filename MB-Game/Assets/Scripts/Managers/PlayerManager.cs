using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    Camera main;
    CameraManager CameraManager;
    [Header("Player Settings")]
    public NavMeshAgent NavMeshAgent;
    public Animator Animator;
    [Header("Look Settings")]
    [Range(10, 1000)] public float mouseSensitive;
    private float yRotation = 0f;
    [SerializeField] LayerMask layerMask;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CameraManager = GetComponent<CameraManager>();
        main = Camera.main;
    }

    public void Breathing()
    {
        Animator.SetBool("Breathing", NavMeshAgent.velocity.magnitude <= .1f);
    }

    public void Walking()
    {
        Ray ray = main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 floor;

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            if(Physics.Raycast(hit.point, Vector3.down, out RaycastHit hit2, 1000, layerMask))
            {
                floor = hit2.point;
            }
            else
            {
                floor= hit.point;
            }
            NavMeshAgent.SetDestination(floor);
            Debug.DrawRay(main.transform.position, hit.point, Color.white, 2f);
        }
    }

    public void Focus(bool value)
    {
        CameraManager.SetFocus(value);
    }

    public void Look()
    {
        //Eixo X (Horizontal)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitive * Time.deltaTime;
        this.transform.Rotate(Vector3.up * mouseX);

        //Eixo Y (Vertical)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitive * Time.deltaTime;
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -75f, 75f);
        main.transform.parent.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

    }
}
