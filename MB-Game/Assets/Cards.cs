using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cards : MonoBehaviour, IInteractable
{
    private GameManager manager;
    public bool reading = false;

    public void Interact()
    {
        manager.Cards = this;
        CallCardsTrigger();
        reading = true;
        manager.Letter(reading);
    }

    void Start()
    {
        manager = FindObjectOfType<GameManager>(); 
    }


    void Update()
    {
        if (reading == true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            manager.Letter(false);
        }

    }

    public int CallCardsTrigger() 
    {
        var id = int.Parse(gameObject.name);

        return id;
    }
}
