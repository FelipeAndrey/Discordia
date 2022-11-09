using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class OnOff : MonoBehaviour
{
    private Light light;
    private bool lights;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(LightBroken(2f));
    }
    private IEnumerator LightBroken(float value) 
    {
        if (lights)
        {
            light.enabled = false;
            lights = false;
        }
        yield return new WaitForSeconds(value);
        if (!lights)
        {
            light.enabled = true;
            lights = true;
        }
        yield return null;  
        
    }
}
