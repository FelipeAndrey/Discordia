using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickZoom : MonoBehaviour
{
    public int zoom = 25;
    public float zoomSmooth = 5f;
    private int normalFOV = 60;
    private bool isZoom = false;

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(1))
        {
            isZoom = !isZoom;
        }
        if (isZoom)
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * zoomSmooth);
        }
        else
        {
            GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normalFOV, Time.deltaTime * zoomSmooth);
        }
    }
}
