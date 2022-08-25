using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    public Light luz;
    public float intencidade = 1;
    public bool luzAtiva; 


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

}
