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

    [Header("Have Thoughts")]
    public Thoughts thoughts;
    public float waitForThoughts = 0f;

    [System.NonSerialized] public bool collided;

    //private bool trade = false;

    public override void Interact()
    {
        if (waitTime > 0)
        {
            StartCoroutine(AfterEvent(waitTime));
        }
        TriggerDialogue(true);
    }

    void Update()
    {
        waitTime = manager.time;
        if (collided && autoDialogue)
        {
            if (waitTime > 0)
            {
                StartCoroutine(AfterEvent(waitTime));
            }
            TriggerDialogue(true);
            if (needToSet != null)
                needToSet.gameObject.SetActive(false);
            collided = false;
        }
    }

    public void TriggerDialogue(bool value)
    {
        if (notMove == true)
            manager.Manager.SetMoving(false);

        if (activeAnimation && parameter != null)
            manager.Manager.animator.SetBool(parameter, true);

        if (thoughts != null)
            manager.thoughts = thoughts;

        manager.canNext = nextDialogue;
        manager.Dialogue(value, dialogue, this.gameObject, waitForThoughts);
    }

    IEnumerator AfterEvent(float value) 
    {
        yield return new WaitForSeconds(value + 2f);
        TriggerDialogue(true);
        if (gameObject.name == "Porta de Escritório")
        {
            manager.Manager.puzzleValueFinal = 2;
        } 
        else if (gameObject.name == "Porta de Leito") 
        {
            manager.Manager.puzzleValueFinal = 1;
        }
        manager.time = 0f;
        yield return null;
    }

    #region OnTriggers

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
    #endregion

    //private void TradeCamera()
    //{
    //    trade = !trade;
    //    TriggerDialogue(trade);
    //}
}
