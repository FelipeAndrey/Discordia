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
    public float waitAnimate;
    public bool notMove;


    [Header("Automatic Dialogue")]
    public bool nextDialogue;
    public bool autoDialogue;
    [System.NonSerialized] public bool collided;

    //private bool trade = false;
    public override void Interact()
    {
        TriggerDialogue(true, 0);
    }

    void Update()
    {
        waitAnimate = manager.time;
        if (collided && autoDialogue)
        {
            if (waitAnimate > 0)
            {
                StartCoroutine(EventAfterAnimation(waitAnimate));
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

        manager.canNext = nextDialogue;
        manager.Dialogue(value, dialogue);

    }

    IEnumerator EventAfterAnimation(float value) 
    {
        print("Entrou");
        yield return new WaitForSeconds(value + 2f);
        TriggerDialogue(true, value);
        manager.time = 0f;
        yield return null;
    }
}
