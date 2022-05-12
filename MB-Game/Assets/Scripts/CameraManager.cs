using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Camera main;

    void Start()
    {
        main = Camera.main;
    }

    public void CameraTrade(Camera target)
    {
        main.enabled = false;
        target.enabled = true;
    }

    public void CameraZoom(bool active)
    {
        int zoom = 25;
        float zoomSmooth = 5f;
        int normalFOV = 60;

        if (active)
        {
            main.fieldOfView = Mathf.Lerp(main.fieldOfView, zoom, Time.deltaTime * zoomSmooth);
        }
        else
        {
            main.fieldOfView = Mathf.Lerp(main.fieldOfView, normalFOV, Time.deltaTime * zoomSmooth);
        }
        
    }
}
