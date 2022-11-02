using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : Interactable
{
    [Header("Porta")]
    public GameObject Door;
    public GameObject needHideAnything;
    public bool needToInteract;
    [HideInInspector]
    public bool interacted = false;

    [Header("ImagemMap")]
    public Image newImage;
    public GameObject imageHolder;

    [Header("Setting Triggers")]
    public TriggersStructur[] needToSet;

    public override void Interact()
    {
        interacted = true;
        DestroyDoor();
    }

    public void DestroyDoor()
    {
        Destroy(Door);
        if (!needToInteract)
        {
            Destroy(this.gameObject);
            return;
        }

        if (needHideAnything != null)
            needHideAnything.SetActive(false);

        if (needToSet != null && interacted)
        {
            foreach (var set in needToSet)
            {
                if (set.elemento != null)
                {
                    set.elemento.enabled = set.setValueBoxCollider;
                }
                if (set.gameObject != null)
                {
                    set.gameObject.SetActive(set.setValueGameObject);
                }
            }
        }
    }
}
