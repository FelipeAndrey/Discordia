using UnityEngine;

public class OpenDoor : Interactable
{
    public GameObject Door;
    public GameObject needHideAnything;
    public override void Interact()
    {
        DestroyDoor();
    }

    public void DestroyDoor()
    {
        gameObject.SetActive(false);
        Destroy(Door);

        if(needHideAnything != null)
            needHideAnything.SetActive(false);
    }
}
