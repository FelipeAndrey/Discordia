using UnityEngine;

public class Cards : Interactable
{
    private GameManager manager;
    [HideInInspector] public bool reading, read = false;

    [Header("Setting Triggers")]
    public TriggersStructur[] needToSet;

    public override void Interact()
    {
        manager.audioManager.Play("WaterDrop");
        manager.SetMoving(false);
        manager.Cards = this;
        CallCardsTrigger();
        reading = true;
        read = true;
        manager.Letter(reading);

        if (needToSet != null && read)
        {
            foreach (var set in needToSet)
            {
                if (set.elemento != null)
                {
                    set.elemento.enabled = set.setValueBoxCollider;

                }
                if (set.gameObject != null)
                {
                    set.gameObject.SetActive(set.setValueGameObject);
                }
            }
        }
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
                if (set.elemento != null)
                {
                    set.elemento.enabled = set.setValueBoxCollider;

                }
                if (set.gameObject != null)
                {
                    set.gameObject.SetActive(set.setValueGameObject);
                }
            }
        }
    }

    public int CallCardsTrigger()
    {
        var id = int.Parse(gameObject.name);

        return id;
    }


}
