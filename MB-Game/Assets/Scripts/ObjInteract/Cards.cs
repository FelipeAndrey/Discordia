using UnityEngine;

public class Cards :  Interactable
{
    private GameManager manager;
    public bool reading = false;

    public override void Interact()
    {
        manager.player.lanternMode = InputLanternMode.OnClick;
        if (reading)
        {
            return;
        }
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
        }

    }

    public int CallCardsTrigger()
    {
        var id = int.Parse(gameObject.name);

        return id;
    }
}
