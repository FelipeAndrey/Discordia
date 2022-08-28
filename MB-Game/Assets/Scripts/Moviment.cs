using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moviment : MonoBehaviour
{
    [SerializeField] Transform Orientetion;

    [Header("Objetos")]
    private new Camera camera;
    public GameManager gameManager;
    public CharacterController controller;

    [Header("Moviment")]
    public float gravity = -9.81f;
    private Vector3 velocity;

    [Header("Stamina")]
    //Stamina
    public float stamina = 100f;
    [SerializeField] private float maxStamina = 100f;
    [Range(0, 50)][SerializeField] private float decriStamina = 0.5f;
    [Range(0, 50)][SerializeField] private float staminaRegen = 0.5f;

    [Header("Speed")]
    //Velocidades
    public float speedCrounch = 3f;
    public float speedRunning = 15;
    public float normalSpeed;
    public float currentScale = 3.5f;
    private float scalePlayer, currentSpeed;

    [Header("Bool")]
    //Boleana
    [HideInInspector] public bool crouch = false;
    [HideInInspector] public bool running;
    [HideInInspector] public bool hasRegenStamina;
    [HideInInspector] public bool isMovin;

    [Header("Stamina UI elements")]
    [SerializeField] private Image staminaProgressUI;
    [SerializeField] private CanvasGroup sliderCanvasGroup;

    [Header("Interact")]
    public float distanceToInteract = 4f;

    private void Start()
    {
        camera = gameManager.GetCamera();
        normalSpeed = speed;
    }

    private void Update()
    {
        Movimente();
        Interacte();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !crouch && stamina > 0)
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1 || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1)
            {
                currentSpeed = speedRunning;
                running = true;
                drainStamina();

            }
            else
            {
                running = false;
                gainStamina();

                if (stamina >= maxStamina - 0.1f)
                {
                    updateStamina(0);
                }

            }

            updateStamina(1);
        }
        else
        {
            currentSpeed = normalSpeed;
            running = false;
            gainStamina();

            if(stamina >= maxStamina - 0.1f) {
              updateStamina(0);
            }
              
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            crouch = true;
            scalePlayer = 0.5f;
            currentSpeed = speedCrounch;

        }
        else if (!running)
        {
            if (Physics.Raycast(camera.transform.position, camera.transform.up, controller.height + 0.2f, LayerMask.GetMask("Ground")) && !crouch)
            {
                return;
            }
            crouch = false;
            scalePlayer = currentScale;
            currentSpeed = normalSpeed;
        }

        speed = currentSpeed;
        controller.height = Mathf.Lerp(controller.height, scalePlayer, 4 * Time.deltaTime);
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
        
    }

    #region Moviment

    private void Movimente() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isMovin = true;

        if (isMovin)
        {
            Vector3 move = Orientetion.right * x + Orientetion.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        

    }
    private void drainStamina()
    {
        if (running)
        {
            stamina -= decriStamina * Time.deltaTime;
        }
    }

    private void gainStamina()
    {
        if (!running && stamina <= maxStamina - 0.01f)
        {
            stamina += staminaRegen * Time.deltaTime;
            updateStamina(1);
        }
    }

    private void updateStamina(int value) 
    {
        staminaProgressUI.fillAmount = stamina / maxStamina;

        if (value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }

    #endregion

    #region Get & Set
    public float speed { get; set; } = 8;
    #endregion
}