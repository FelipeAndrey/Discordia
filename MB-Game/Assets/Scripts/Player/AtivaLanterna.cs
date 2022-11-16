using UnityEngine;

public class AtivaLanterna : Interactable
{
    private GameManager manager;
    public GameObject lantern;
    public GameObject Door;

    private void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
    }

    public void Ativação()
    {
        lantern.SetActive(true);
        this.gameObject.SetActive(false);
        Destroy(Door);
        manager.audioManager.Play("PedraCaindo");
    }

    public override void Interact()
    {
        Ativação();
    }
}
