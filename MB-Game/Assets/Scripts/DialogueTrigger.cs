using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DialogueTrigger : Interactable
{
    [Header("Dialogue Settings")]
    public DialogueStructure dialogue;
    public DialogueManager manager;
    public Camera targetCamera;

    [Header("Automatic Dialogue")]
    public bool autoDialogue;
    [System.NonSerialized] public bool collided;

    private bool trade = false;
    public override void Interact() 
    {
        TriggerDialogue(true);
    }

    void Update()
    {
        if (collided)
        {
            if (autoDialogue)
            {
                TriggerDialogue(true);
                collided = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            collided = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            collided = false;
        }
    }

    private void TradeCamera()
    {
        trade = !trade;
        TriggerDialogue(trade);
    }

    public void TriggerDialogue(bool value)
    {
        manager.Dialogue(value, dialogue);
    }
}
