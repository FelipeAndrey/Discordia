using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : Interactable
{
    [Header("Porta")]
    public GameObject Door;
    public GameObject needHideAnything;
    public bool needToInteract;

    [Header("ImagemMap")]
    public Image newImage;
    public GameObject imageHolder;

    public override void Interact()
    {
        DestroyDoor();
    }

    public void DestroyDoor()
    {
        if (!needToInteract)
        {
            Destroy(this.gameObject);
            return;
        }
        
        gameObject.SetActive(false);
        Destroy(Door);

        if(needHideAnything != null)
            needHideAnything.SetActive(false);
    }

    public void ChangeMapIMG() 
    {
    
    }
}
