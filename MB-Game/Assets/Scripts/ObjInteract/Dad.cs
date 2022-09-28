using UnityEngine;

public class Dad : Interactable
{
    public GameObject Door;

    public override void Interact()
    {

    }

    public void Some()
    {
        Destroy(gameObject);
        Destroy(Door);
    }
}
