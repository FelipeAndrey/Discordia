using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : MonoBehaviour
{
    Camera main;
    CameraManager CameraManager;
    [Header("Player Settings")]
    public NavMeshAgent navMeshAgent;
    public Animator Animator;
    public float distMin;
    [Header("Look Settings")]
    [Range(10, 1000)] public float mouseSensitive;
    [SerializeField] LayerMask layerMask;

    #region Gets & Sets
    public int Sannity { get; set; } = 100;
    public int distanceClick { get; set; } = 1000;
    #endregion

    //Gets & Sets Variáveis
    private float yRotation = 0f;
    private bool canWalk = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CameraManager = GetComponent<CameraManager>();
        main = Camera.main;
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance > 0 && navMeshAgent.remainingDistance < distMin && canWalk)
        {
            canWalk = false;
            navMeshAgent.isStopped = true;
            FindObjectOfType<AudioManager>().Stop("PlayerWalk");
        }
    }

    public void Breathing()
    {
        Animator.SetBool("Breathing", navMeshAgent.velocity.magnitude <= .1f);
    }

    public void Walking()
    {
        canWalk = true;
        navMeshAgent.isStopped = false;
        Ray ray = main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 floor;

        if (Physics.Raycast(ray, out hit, distanceClick, layerMask))//Disparo em linha reta
        {
            //Autodisparo ponto no chão
            if (Physics.Raycast(hit.point, Vector3.down, out RaycastHit hit2, distanceClick, layerMask))
            {
                floor = hit2.point;
            }
            else
            {
                floor = hit.point;
            }

            if (navMeshAgent.remainingDistance < distMin)
            {
                FindObjectOfType<AudioManager>().Play("PlayerWalk");
            }

            navMeshAgent.SetDestination(floor);

            //Debug.DrawRay(main.transform.position, hit.point, Color.white, 2f);
        }
        //Animator.SetBool("Walking", NavMeshAgent.velocity.magnitude > .1f);
    }

    public void Focus(bool value)
    {
        CameraManager.Focus = value;
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
    
    #region Gets & Sets Métodos
    /// <summary>
    /// Retorna o valor atual da condição booleana <c>canWalk</c> referente ao recurso de movimentação do player.
    /// </summary>
    /// <returns>Retorna um valor: <c>bool</c></returns>
    public bool GetWalk()
    {
        return canWalk;
    }
    /// <summary>
    /// Altera o valor atual da condição booleana <c>canWalk</c> referente ao recurso de movimentação do player.
    /// </summary>
    public void SetWalk(bool value)
    {
        canWalk = value;
    }

    public void SetSpeed(float value)
    {
        navMeshAgent.speed = value;
    }
    public void SetAcceleration(float value)
    {
        navMeshAgent.acceleration = value;
    }
    #endregion
}
