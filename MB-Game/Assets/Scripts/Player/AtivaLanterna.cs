using UnityEngine;

public class AtivaLanterna : Interactable
{
    public GameObject lantern;

    public GameObject Door;

    public void Ativação()
    {
        lantern.SetActive(true);
        this.gameObject.SetActive(false);
        Destroy(Door);
    }

    public override void Interact()
    {
        Ativação();
    }
}
