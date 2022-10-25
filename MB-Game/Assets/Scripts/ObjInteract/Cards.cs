using UnityEngine;

public class Cards : Interactable
{
    private GameManager manager;
    public bool reading;

    public override void Interact()
    {
        manager.SetMoving(false);
        manager.Cards = this;
        CallCardsTrigger();
        reading = true;
        manager.Letter(reading);
    }

    void Start()
    {
        manager = FindObjectOfType<GameManager>();

    }


    void Update()
    {
        if (reading == true && Input.GetKeyDown(KeyCode.Mouse1))
        {
            manager.Letter(false);
            reading = false;
            manager.SetMoving(true);
        }
    }

    public int CallCardsTrigger()
    {
        var id = int.Parse(gameObject.name);

        return id;
    }


}
