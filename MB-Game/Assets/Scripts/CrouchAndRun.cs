using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchAndRun : MonoBehaviour
{
    //Velocidades
    public float speedCrounch = 3f, speedRunning = 15, normalSpeed, currentScale =3.5f;
    private float scalePlayer, currentSpeed;
    private float breath;

    //Personagem
    private Moviment Move;
    private CharacterController controller;

    //Boleana
    private bool crouch, running;


    // Start is called before the first frame update
    void Start()
    {
        Move = GetComponent<Moviment>();
        controller = GetComponent<CharacterController>();
        scalePlayer = controller.height;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Move.groundCheck && !crouch)
        {
            currentSpeed = speedRunning;
            running = true;
        }
        else 
        {
            currentSpeed = normalSpeed;
            running = false;
        }
        if (Input.GetKey(KeyCode.LeftControl) && Move.groundCheck)
        {
            crouch = true;
            scalePlayer = 0.5f;
            currentSpeed = speedCrounch;

        }else if (!running) 
        {
            crouch = false;
            scalePlayer = currentScale;
            currentSpeed = normalSpeed;
        }

        Move.speed = currentSpeed;
        controller.height = Mathf.Lerp(controller.height, scalePlayer, 3 * Time.deltaTime);
    }
}
