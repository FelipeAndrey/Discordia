using System.Collections;
using System.Threading;
using UnityEngine;

public class DialogueTrigger : Interactable
{
    [Header("Dialogue Settings")]
    public DialogueStructure[] dialogue;
    public DialogueManager manager;
    public Camera targetCamera;
    public BoxCollider needToSet;
    public float waitTime = 0f;

    [Header("Automatic Dialogue")]
    public bool nextDialogue;
    public bool autoDialogue;

    [Header("Set Player")]
    public bool notMove;
    public bool activeAnimation;
    public string parameter;

    [System.NonSerialized] public bool collided;

    //private bool trade = false;
    public override void Interact()
    {
        if (waitTime > 0)
        {
            StartCoroutine(EventAfterAnimation(waitTime));
        }
        TriggerDialogue(true, waitTime);
    }

    void Update()
    {
        waitTime = manager.time;
        if (collided && autoDialogue)
        {
            if (waitTime > 0)
            {
                StartCoroutine(EventAfterAnimation(waitTime));
            }
            TriggerDialogue(true, 0);
            if (needToSet != null)
                needToSet.enabled = false;
            collided = false;
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

    //private void TradeCamera()
    //{
    //    trade = !trade;
    //    TriggerDialogue(trade);
    //}

    public void TriggerDialogue(bool value, float time)
    {
        if (notMove == true)
        {
            manager.Manager.SetMoving(false);
        }

        if (activeAnimation && parameter != null)
        {
            manager.Manager.animator.SetBool(parameter, true);
        }

        manager.canNext = nextDialogue;
        manager.Dialogue(value, dialogue);

    }

    IEnumerator EventAfterAnimation(float value) 
    {
        yield return new WaitForSeconds(value + 2f);
        TriggerDialogue(true, value);
        manager.time = 0f;
        yield return null;
    }
}
