using UnityEngine;

public class AtivaLanterna : Interactable
{
    public GameObject lantern;

   

    public void Ativação()
    {
        lantern.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        Ativação();

    }
}
