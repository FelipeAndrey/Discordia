using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private PlayerInput playerInput;
    public float speed = 5f;
    public float mouseSensitivty = 100f;
    //private float xRotation = 0f;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }

    private void Update()
    {
        movePlayer();
    }

    private void movePlayer() 
    {
        Vector2 inputVector = playerInput.Player.Movement.ReadValue<Vector2>();
        playerRigidbody.velocity = new Vector3(inputVector.x, 0, inputVector.y) * speed * Time.deltaTime;
    }



}
