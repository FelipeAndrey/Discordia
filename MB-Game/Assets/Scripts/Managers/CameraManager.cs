using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Get Main Camera")]
    public Camera main;
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

    public void Trade(Camera target)
    {
        main.enabled = false;
        target.enabled = true;
    }

    public void ActiveZoom()
    {
        main.fieldOfView = Mathf.Lerp(main.fieldOfView, zoom, Time.deltaTime * ZoomSpeed);
    }

    public void DesactiveZoom()
    {
        main.fieldOfView = Mathf.Lerp(main.fieldOfView, normalFOV, Time.deltaTime * ZoomSpeed);
    }

    public bool GetFocus()
    {
        return inFocus;
    }

    public void SetFocus(bool value)
    {
        inFocus = value;
    }
}
