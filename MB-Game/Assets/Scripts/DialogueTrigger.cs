using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Dialogue Settings")]
    public DialogueStructure dialogue;
    public DialogueManager manager;
    public Camera targetCamera;

    [Header("Automatic Dialogue")]
    public bool autoDialogue;
    private bool collided;

    private bool trade = false;

    void Update()
    {
        if (collided)
        {
            if (autoDialogue)
            {
                TriggerDialogue(true);
                collided = false;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    TradeCamera();
                }
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
        manager.TargetCameraTrade(targetCamera);
        manager.ActiveCameraTrade(trade);
        TriggerDialogue(trade);
    }

    public void TriggerDialogue(bool value)
    {
        manager.Dialogue(value, dialogue, this);
    }
}
