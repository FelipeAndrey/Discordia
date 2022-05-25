using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bargain : MonoBehaviour
{
    public BargainManager BargainManager;
    public DialogueTrigger DialogueTrigger;
    public GameObject BargainTrigger, BargainTarget;
    #region Bargain Settings
    public enum Category { Local, Interactive }
    public enum Type { HUD, Behavior, VFX, Camera}
    #endregion
    public Category category;
    public Type type;
    [TextArea(1, 2)]public string description;
    public int bargainID { get; set; }

    #region Privates
    private bool collided;
    #endregion

    private void Update()
    {
        if (collided)
        {
            if (category.ToString() == "Interactive")//In Interactive Case
            {
                DialogueTrigger.manager.canNext = DialogueTrigger.manager.sentences.Count == 0 ? false : true;
                if (DialogueTrigger.manager.onDialogue && DialogueTrigger.manager.canNext == false && Input.GetKeyUp(KeyCode.Y))
                {
                    BargainManager.Type = type.ToString();
                    BargainManager.StartBargain(this);
                    BargainManager.Interactive(BargainTarget);
                    DialogueTrigger.manager.EndDialogue();
                    bargainID = BargainManager.Bargain.Count - 1;
                    this.gameObject.SetActive(false);
                }
                else if(Input.GetKeyUp(KeyCode.N))
                {
                    DialogueTrigger.manager.EndDialogue();
                }
            }else if (!this.DialogueTrigger.manager.onDialogue)//In Local Case
            {
                BargainManager.StartBargain(this);
                BargainTrigger.gameObject.SetActive(true);
                BargainTrigger.GetComponent<ActivateBargainTrigger>().ID = bargainID;
                bargainID = BargainManager.Bargain.Count - 1;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
    }
}
