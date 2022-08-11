using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    [SerializeField] Transform Orientetion;

    private new Camera camera;
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    private Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groudMask;

    private bool isGrounded;

    public float distanceToInteract = 4f;

    private void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        moviment();
        Jump();
        Interacte();
    }

    private void Interacte() 
    {
        RaycastHit hitInfo;

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, distanceToInteract, LayerMask.GetMask("Interact"))) 
            {
                IInteractable obj = hitInfo.transform.GetComponent<IInteractable>();

                if (obj == null) return;

                obj.Interact();
            }
        }
        /*else if(Input.GetKeyDown(KeyCode.E)) 
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.right, out hitInfo, distanceToInteract, LayerMask.GetMask("Lantern"))) 
            {
                IInteractable obj = hitInfo.transform.GetComponent<IInteractable>();

                if (obj == null) return;

                obj.Interact();
            }
        
        }*/
    }
    #region Moviment
    private void Jump() 
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groudMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

    }

    private void moviment() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Orientetion.right * x + Orientetion.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
    #endregion
}
