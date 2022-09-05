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
