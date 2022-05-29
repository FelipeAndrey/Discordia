using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bargain : MonoBehaviour
{
    #region Bargain Settings
    public enum Category { Local, Interactive }
    public enum Type { HUD, Behavior, VFX, Camera }
    #endregion
    public BargainManager BargainManager;
    public DialogueTrigger DialogueTrigger;
    public GameObject BargainTrigger, BargainTarget = null;
    public Category category;
    public Type type;
    [TextArea(1, 2)]public string description;
    public int bargainID { get; set; }

    #region Privates
    private bool collided;
    #endregion

    #region OnTriggerCollider
    private void OnTriggerEnter(Collider other)
    {
        collided = true;
    }
    private void OnTriggerExit(Collider other)
    {
        collided = false;
    }
    #endregion

    private void Update()
    {
        if (collided)
        {
            Debug.Log(this.category.ToString());
            if (this.category.ToString() == "Interactive")//In Interactive Case
            {
                Interactive();
                if (Input.GetKeyDown(KeyCode.N))
                {
                    DialogueTrigger.manager.EndDialogue();
                }
                
            }else//In Local Case
            {
                Local();
                if (Input.GetKeyDown(KeyCode.N))
                {
                    DialogueTrigger.manager.EndDialogue();
                }
            }
        }
    }

    public void Interactive() 
    {
        DialogueTrigger.manager.canNext = DialogueTrigger.manager.sentences.Count == 0 ? false : true;
        if (DialogueTrigger.manager.onDialogue && DialogueTrigger.manager.canNext == false && Input.GetKeyUp(KeyCode.Y))
        {
            BargainManager.Type = type.ToString();
            BargainManager.AddBargain(this);
            bargainID = BargainManager.Bargain.Count;
            if (BargainTarget != null)
            {
                BargainManager.Interactive(BargainTarget);
            }
            DialogueTrigger.manager.EndDialogue();
            collided = false;
        }
    }

    public void Local() 
    {
        BargainManager.AddBargain(this);
        BargainTrigger.gameObject.SetActive(true);
        bargainID = BargainManager.Bargain.Count;
        BargainTrigger.GetComponent<LocalTrigger>().ID = bargainID;
        DialogueTrigger.manager.canNext = true;
        if(DialogueTrigger.manager.sentences.Count == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            DialogueTrigger.manager.canNext = false;
            DialogueTrigger.manager.EndDialogue();
        }
        this.gameObject.SetActive(false);
        collided = false;
    }
}
