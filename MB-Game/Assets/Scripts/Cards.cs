using UnityEngine;

public class Cards : MonoBehaviour, IInteractable
{
    private GameManager manager;
    public bool reading = false;

    public void Interact()
    {
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
