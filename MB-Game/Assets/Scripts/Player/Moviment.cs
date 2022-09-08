using System;
using UnityEngine;
using UnityEngine.UI;

public class Moviment : MonoBehaviour
{
    public Lantern lantern;
    public Transform lanterRef;

    [SerializeField] Transform Orientetion;

    [Header("Canvas")]
    public Image crossHair;

    [Header("Objetos")]
    private new Camera camera;
    public GameManager gameManager;
    public CharacterController controller;
    public InputLanternMode lanternMode;

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
    public float normalSpeed = 8;
    public float currentScale = 3.5f;
    private float scalePlayer, currentSpeed;

    [Header("Bool")]
    //Boleana
    /*[HideInInspector]*/
    public bool crouch = false;
    /*[HideInInspector]*/
    public bool running;
    [HideInInspector] public bool hasRegenStamina;
    [HideInInspector] public bool isMovin = false;

    [Header("Stamina UI elements")]
    [SerializeField] private Image staminaProgressUI;
    [SerializeField] private CanvasGroup sliderCanvasGroup;

    [Header("Interact")]
    public float distanceToInteract = 4f;

    private void Start()
    {
        camera = Camera.main;
        camera = gameManager.GetCamera();
        normalSpeed = speed;
        currentSpeed = normalSpeed;
    }

    private void Update()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal")) < 0.1 && Mathf.Abs(Input.GetAxis("Vertical")) < 0.1)
        {
            isMovin = false;
        }
        else
        {
            isMovin = true;
            Movimente();
        }

        Correr();
        Abaixar();
        Interacte();
        gameManager.Breathing();

        speed = currentSpeed;
    }

    private void Interacte()
    {
        RaycastHit hitInfo;

        var objInteract = Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, distanceToInteract, LayerMask.GetMask("Interact"));

        CrosshairImageChange(objInteract);

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, distanceToInteract, LayerMask.GetMask("Interact")))
        {
            if (hitInfo.transform.TryGetComponent<Interactable>(out Interactable obj))
            {
                if (obj.InputLanternMode == InputLanternMode.OnClick)
                {
                    if (!Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        return;
                    }
                }

                obj.Interact(); 
            
            }
        }
    }

    private void CrosshairImageChange(bool objInteract)
    {
        if (objInteract)
        {
            crossHair.color = Color.red;
            //crossHair.sprite = nova imagem
        }
        else
        {
            crossHair.color = Color.white;
            //crossHair.sprite = volta para a outra imagem
        }
    }

    #region Moviment

    private void Movimente()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Orientetion.right * x + Orientetion.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Abaixar()
    {
        bool estaEmBaixo = false;
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.up, out hit, LayerMask.GetMask("Ground")))
        {
            if (hit.collider.gameObject.tag == "ObsCabeca")
            {
                estaEmBaixo = true;
            }
            else
            {
                estaEmBaixo = false;
            }
        }

        if (Input.GetKey(KeyCode.LeftControl) && !running && !crouch)
        {
            crouch = true;
            scalePlayer = 0.5f;
            currentSpeed = speedCrounch;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouch = false;
            scalePlayer = 3.5f;
        }
        if (crouch && controller.height > scalePlayer)
        {
            controller.height = Mathf.Lerp(controller.height, scalePlayer, 4 * Time.deltaTime);
        }
        else if (!crouch && controller.height < scalePlayer && !estaEmBaixo)
        {
            controller.height = Mathf.Lerp(controller.height, scalePlayer, 4 * Time.deltaTime);
        }
        if (controller.height >= 3.4f && !running && !crouch)
        {
            currentSpeed = normalSpeed;
        }
    }

    private void Correr()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !crouch && stamina > 0 && controller.height >= 3.4f)
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1 || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1)
            {
                currentSpeed = speedRunning;
                running = true;
                drainStamina();
                updateStamina(1);
            }
            else
            {
                currentSpeed = normalSpeed;
                running = false;
                gainStamina();

                if (stamina >= maxStamina - 0.1f)
                {
                    updateStamina(0);
                }
            }
        }
        else
        {
            gainStamina();

            if (stamina >= maxStamina - 0.1f)
            {
                updateStamina(0);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && controller.height >= 3.4f)
        {
            currentSpeed = normalSpeed;
            running = false;
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
    private float speed { get; set; } = 8;
    #endregion
}

[Serializable]
public enum InputLanternMode {Automatic, OnClick }