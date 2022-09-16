using UnityEngine;

public class DialogueTrigger : Interactable
{
    [Header("Dialogue Settings")]
    public DialogueStructure dialogue;
    public DialogueManager manager;
    public Camera targetCamera;
    public BoxCollider needToSet;
    public bool notMove;


    [Header("Automatic Dialogue")]
    public bool nextDialogue;
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
            print("Entrou");
            if (autoDialogue)
            {
                TriggerDialogue(true);
                needToSet.enabled = false;
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
        if(notMove == true)
        {
            manager.Manager.player.canMove = false;
        }
        else
        {
            manager.Manager.player.canMove = true;
        }
        manager.canNext = nextDialogue;
        manager.Dialogue(value, dialogue);
    }
}
