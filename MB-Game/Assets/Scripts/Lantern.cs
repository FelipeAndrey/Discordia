using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour, IInteractable
{
    public Light luz;
    public float intencidade = 1;
    public bool luzAtiva; 

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
            luzAtiva = !luzAtiva;
            luz.gameObject.SetActive(luzAtiva);
        }
    }

    private void LigaDesliga() 
    {
 
        luzAtiva = !luzAtiva;
        luz.gameObject.SetActive(luzAtiva);
    }
}
