using UnityEngine;

public class Cards : Interactable
{
    private GameManager manager;
    public bool reading, read = false;

    [Header("Setting Triggers")]
    public TriggersStructur[] needToSet;

    public override void Interact()
    {
        manager.SetMoving(false);
        manager.Cards = this;
        CallCardsTrigger();
        reading = true;
        read = true;
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

        if (needToSet != null && read)
        {
            foreach (var set in needToSet)
            {
                if (set != null)
                    set.elemento.enabled = set.setValue;
            }
        }
    }

    public int CallCardsTrigger()
    {
        var id = int.Parse(gameObject.name);

        return id;
    }


}
