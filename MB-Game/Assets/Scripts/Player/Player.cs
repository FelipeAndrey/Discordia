using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //public Lantern lantern;
    //public Transform lanterRef;

    [SerializeField] Transform Orientetion;

    [Header("Canvas")]
    [SerializeField] private Image p_crossHair;

    [Header("Objetos")]
    private GameManager p_gameManager;
    private CharacterController p_controller;
    [SerializeField] private InputLanternMode lanternMode;
    private new Camera camera;

    [Header("Moviment")]
    [SerializeField] private float p_gravity = -9.81f;
    private Vector3 p_velocity;

    [Header("Stamina")]
    //Stamina
    //[Range(0, 50)][SerializeField] private float staminaRegen = 0.5f;
    //[Range(0, 50)][SerializeField] private float decriStamina = 0.5f;
    [SerializeField] private float p_stamina = 100f;
    [SerializeField] private float p_maxStamina = 100f;

    [Header("Speed")]
    //Velocidades
    //[SerializeField] private float speedRunning = 15;
    [SerializeField] private float p_speedCrounch = 3f;
    [SerializeField] private float p_normalSpeed = 8;
    [SerializeField] private float p_currentScale;
    private float p_scalePlayer, p_currentSpeed;

    [Header("Bool")]
    //Boleana
    //[SerializeField] private bool hasRegenStamina;
    [SerializeField] private bool p_crouch = false;
    [SerializeField] private bool p_running;


    [Header("Stamina UI elements")]
    [SerializeField] private Image p_staminaProgressUI;
    [SerializeField] private CanvasGroup sliderCanvasGroup;

    [Header("Interact")]
    [Range(0, 10)] [SerializeField] private float p_distanceToInteract;

    private void Start()
    {
        p_controller = GetComponent<CharacterController>();
        p_gameManager = GameObject.FindObjectOfType<GameManager>();
        camera = Camera.main;
        camera = p_gameManager.GetCamera();
        p_normalSpeed = Speed;
        p_currentSpeed = p_normalSpeed;
    }

    private void Update()
    {
        if (CanMove)
        {
            Movimente();
        }

        //Correr();
        Abaixar();
        Interacte();
        p_gameManager.Breathing();
        Speed = p_currentSpeed;
    }

    private void Interacte()
    {
        RaycastHit hitInfo;

        var objInteract = Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, p_distanceToInteract, LayerMask.GetMask("Interact"));

        CrosshairImageChange(objInteract);

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, p_distanceToInteract, LayerMask.GetMask("Interact")))
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
            p_crossHair.color = Color.red;
            //p_crossHair.sprite = nova imagem
        }
        else
        {
            p_crossHair.color = Color.white;
            //p_crossHair.sprite = volta para a outra imagem
        }
    }

    #region Moviment


    private void Movimente()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        p_velocity.y += p_gravity * Time.deltaTime;
        Vector3 move = new Vector3();

        if (Mathf.Abs(x) < 0.1 && Mathf.Abs(z) < 0.1)
        {
            p_gameManager.audioManager.Play("Pasos");
            IsMoving = false;
        }
        else
        {
            move = Orientetion.right * x + Orientetion.forward * z;
            move = new Vector3(move.x, p_velocity.y, move.z);
            move = new Vector3(move.x, 0, move.z).normalized;
            IsMoving = true;

        }
        p_controller.Move(move * Speed * Time.deltaTime);
        p_controller.Move(p_velocity * Time.deltaTime);
    }
    private void Abaixar()
    {
        bool estaEmBaixo = false;
        RaycastHit hit;

        if (Physics.Raycast(Orientetion.transform.position, Orientetion.transform.up, out hit, LayerMask.GetMask("Ground")))
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

        if (Input.GetKey(KeyCode.LeftControl) && !p_running && !p_crouch)
        {
            p_crouch = true;
            p_scalePlayer = 0.5f;
            p_currentSpeed = p_speedCrounch;
            //Orientetion.transform.position = new Vector3(0, 0.5f, 0);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            p_crouch = false;
            p_scalePlayer = p_currentScale;
            //Orientetion.transform.position = new Vector3(0, 3.5f, 0);
        }
        if (p_crouch && p_controller.height > p_scalePlayer)
        {
            p_controller.height = Mathf.Lerp(p_controller.height, p_scalePlayer, 4 * Time.deltaTime);
        }
        else if (!p_crouch && p_controller.height < p_scalePlayer && !estaEmBaixo)
        {
            p_controller.height = Mathf.Lerp(p_controller.height, p_scalePlayer, 4 * Time.deltaTime);
        }
        if (p_controller.height >= 3.4f && !p_running && !p_crouch)
        {
            p_currentSpeed = p_normalSpeed;
        }

        Orientetion.localPosition = new Vector3(0, p_scalePlayer == 0.5f ? 0.5f : 2f, 0);
    }

    //private void Correr()
    //{
    //    if (Input.GetKey(KeyCode.LeftShift) && !p_crouch && p_stamina > 0.1f && p_controller.height >= 3.4f)
    //    {
    //        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1 || Mathf.Abs(Input.GetAxis("Vertical")) > 0.1)
    //        {
    //            p_currentSpeed = speedRunning;
    //            p_running = true;
    //            drainStamina();
    //            updateStamina(1);
    //        }
    //        else
    //        {
    //            p_currentSpeed = p_normalSpeed;
    //            p_running = false;
    //            gainStamina();

    //            if (p_stamina >= p_maxStamina - 0.1f)
    //            {
    //                updateStamina(0);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        gainStamina();

    //        if (p_stamina >= p_maxStamina - 0.1f)
    //        {
    //            updateStamina(0);
    //        }
    //    }
    //    if (Input.GetKeyUp(KeyCode.LeftShift) && p_controller.height >= 3.4f || p_stamina < 0.1f)
    //    {
    //        p_currentSpeed = p_normalSpeed;
    //        p_running = false;
    //    }
    //}
    //private void drainStamina()
    //{
    //    if (p_running)
    //    {
    //        p_stamina -= decriStamina * Time.deltaTime;
    //    }
    //}

    //private void gainStamina()
    //{
    //    if (!p_running && p_stamina <= p_maxStamina - 0.01f)
    //    {
    //        p_stamina += p_staminaRegen * Time.deltaTime;
    //        updateStamina(1);
    //    }
    //}

    private void updateStamina(int value)
    {
        p_staminaProgressUI.fillAmount = p_stamina / p_maxStamina;

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
    private float Speed { get; set; } = 12;
    public bool IsMoving { get; set; }
    public bool CanMove { get; set; } = true;
    #endregion
}

[Serializable]
public enum InputLanternMode { Automatic, OnClick }