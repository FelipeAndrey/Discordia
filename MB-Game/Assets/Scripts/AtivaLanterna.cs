using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaLanterna : MonoBehaviour, IInteractable
{
    public GameObject lantern;

    public void Interact() 
    {
        Ativação();
    }


    public void Ativação() 
    {
        lantern.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
