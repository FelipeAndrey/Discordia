using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Moviment player;
    private Camera cameraAtual;
    public Camera TradeCamaera;

    // Start is called before the first frame update
    void Start()
    {
        cameraAtual = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public Camera GetCamera() 
    {
        return cameraAtual;
    }
    
}
