using UnityEngine;

public class AtivaLanterna : Interactable
{
    public GameObject lantern;



    public void Ativa��o()
    {
        lantern.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        Ativa��o();

    }
}
