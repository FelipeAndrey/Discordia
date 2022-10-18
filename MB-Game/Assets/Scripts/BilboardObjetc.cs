using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilboardObjetc : MonoBehaviour
{
    public GameManager manager;


    private void OnTriggerEnter(Collider other)
    {
        transform.LookAt(manager.cameraAtual.transform);
    }
    private void OnTriggerStay(Collider other)
    {
        transform.LookAt(manager.cameraAtual.transform);
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
