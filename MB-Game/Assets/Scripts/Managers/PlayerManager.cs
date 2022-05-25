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
    [SerializeField] LayerMask layerMask;
    private float yRotation = 0f;
    public int Sannity { get; set; } = 100;

    //Gets & Sets Variáveis
    private bool canWalk = true;

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
        if (canWalk)
        {
            Ray ray = main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 floor;

            //Disparo em linha reta
            if (Physics.Raycast(ray, out hit, 1000, layerMask))
            {
                //Autodisparo ponto no chão
                if (Physics.Raycast(hit.point, Vector3.down, out RaycastHit hit2, 1000, layerMask))
                {
                    floor = hit2.point;
                }
                else
                {
                    floor = hit.point;
                }
                NavMeshAgent.SetDestination(floor);
                Debug.DrawRay(main.transform.position, hit.point, Color.white, 2f);
            }
        }        
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
    //Andar do personagem
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
    #endregion
}
