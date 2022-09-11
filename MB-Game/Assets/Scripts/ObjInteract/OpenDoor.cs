using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interactable
{
    public GameObject Door;

    public List<GameObject> godWords;

    public override void Interact()
    {
        DestroyDoor();
    }

    public void DestroyDoor()
    {

        Destroy(Door);
    }
}
