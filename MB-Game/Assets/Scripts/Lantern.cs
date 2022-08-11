using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour, IInteractable
{
    public Light luz;
    public float intencidade = 1;

    public void Interact() 
    {
        LigaDesliga();
    }
    private void Start()
    {
        GetComponentInChildren<Light>();

        luz.intensity = intencidade;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (this.enabled)
            {
                luz.gameObject.SetActive(true);
            }
            else
            {
                luz.gameObject.SetActive(false);
            }
        }
    }

    public void LigaDesliga() 
    {
        Debug.Log("alow");
        if (luz.enabled)
        {
            luz.gameObject.SetActive(true);
        }
        else 
        {
            luz.gameObject.SetActive(false);
        }
    }
}
