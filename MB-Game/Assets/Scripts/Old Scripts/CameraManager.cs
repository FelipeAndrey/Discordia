using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Get Main Camera")]
    public Camera main;
    private Camera cameraTarget;
    [Header("Camera Focus Settings")]
    [Range(0.1f, 5f)] public float ZoomSpeed;
    public int zoom = 25;
    private bool inFocus = false;
    private int normalFOV = 60;



    void Start()
    {
        main = Camera.main;
    }

    void Update()
    {
        if (inFocus)
        {
            ActiveZoom();
        }
        else
        {
            DesactiveZoom();
        }
    }

    public void Trade(bool value)
    {
        if (value)
        {
            main.enabled = false;
            cameraTarget.enabled = true;
        }
        else
        {
            main.enabled = true;
            cameraTarget.enabled = false;
        }

    }

    public void ActiveZoom()
    {
        main.fieldOfView = Mathf.Lerp(main.fieldOfView, zoom, Time.deltaTime * ZoomSpeed);
    }
    public void DesactiveZoom()
    {
        main.fieldOfView = Mathf.Lerp(main.fieldOfView, normalFOV, Time.deltaTime * ZoomSpeed);
    }

    #region Gets & Sets Métodos
    /// <summary>
    /// Focus habilita e desabilita o sistema de zoom do jogo.
    /// </summary>
    /// <returns>Retorna um valor: <c>True ou False</c></returns>
    public bool Focus { get => inFocus; set => inFocus = value; }
    /// <summary>
    /// CameraTarget indica qual é a camera alvo do objeto.
    /// </summary>
    /// <returns>Retorna um valor do tipo: <c>Camera</c></returns>
    public Camera CameraTarget { get => cameraTarget; set => cameraTarget = value; }
    #endregion
}
