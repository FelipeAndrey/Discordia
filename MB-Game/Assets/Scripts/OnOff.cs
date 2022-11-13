using System.Collections;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public float temp;
    private Light light;
    private bool lights;

    void Start()
    {
        light = GetComponentInChildren<Light>();
    }

    void FixedUpdate()
    {
        StartCoroutine(LightBroken(temp));
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
