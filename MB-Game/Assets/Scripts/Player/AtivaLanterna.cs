using UnityEngine;

public class AtivaLanterna : Interactable
{
    public GameObject lantern;

    public GameObject Door;

    public void Ativa��o()
    {
        lantern.SetActive(true);
        this.gameObject.SetActive(false);
        Destroy(Door);
    }

    public override void Interact()
    {
        Ativa��o();
    }
}
