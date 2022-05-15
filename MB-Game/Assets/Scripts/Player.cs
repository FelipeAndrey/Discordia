using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerManager PlayerManager;
    private bool focus = false;

    void Start()
    {
        PlayerManager = GetComponent<PlayerManager>();
    }

    void Update()
    {
        PlayerManager.Look();
        PlayerManager.Breathing();
        if (Input.GetMouseButtonDown(1)){
            focus = !focus;
            PlayerManager.Focus(focus);
        }
        if (Input.GetMouseButtonDown(0))
        {
            PlayerManager.Walking();
        }
    }
}
