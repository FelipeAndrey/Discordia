using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private GameManager manager;
    public Transform transformRef;
    public float valueOfView;
    public float smoothSpeed = 0.25f;
    float smoothPos;

    private void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        //if (manager.dialogueManager.onDialogue == false)
        //{
        //    manager.cameraAtual.GetComponent<Look>().canLook = true;
        //    manager.player.canMove = true;
        //    manager.cameraAtual.fieldOfView = 60f;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        print("entrou");
        manager.cameraAtual.GetComponent<Look>().canLook = false;
        //manager.player.canMove = false;
    }
    private void OnTriggerStay(Collider other)
    {
        manager.cameraAtual.fieldOfView = Mathf.Lerp(60, valueOfView, Time.deltaTime * (valueOfView*60f));
        manager.cameraAtual.transform.LookAt(transformRef);
        //Vector3.Lerp(manager.cameraAtual.transform.position, transformRef.position, smoothSpeed);
    }
    private void OnTriggerExit(Collider other)
    {
        manager.cameraAtual.GetComponent<Look>().canLook = true;
        //manager.player.canMove = true;
        manager.cameraAtual.fieldOfView = 60f;
    }


}
