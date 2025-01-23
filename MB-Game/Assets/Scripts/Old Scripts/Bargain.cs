using UnityEngine;

public class Bargain : MonoBehaviour
{
    #region Bargain Settings
    public enum Category { Local, Interactive }
    public enum Type { HUD, Behavior, VFX, Camera }
    #endregion
    public BargainManager bargainManager;
    public DialogueTrigger dialogueTrigger;
    public AudioManager audioManager;
    public GameObject bargainTrigger, bargainTarget = null;
    public Category category;
    public Type type;
    [TextArea(1, 2)] public string description;
    public int bargainID { get; set; }

    #region Privates
    //private bool collided;
    #endregion

    #region OnTriggerCollider
    private void OnTriggerEnter(Collider other)
    {
        audioManager.Play("Whisper");
        //collided = true;
    }
    private void OnTriggerExit(Collider other)
    {
        //collided = false;
    }
    #endregion

    private void Update()
    {
        /*if (collided)
        {
            if (this.category.ToString() == "Interactive")//In Interactive Case
            {
                Interactive();
                if (Input.GetKeyDown(KeyCode.N))
                {
                    audioManager.Stop("Whisper");
                    dialogueTrigger.p_Dmanager.EndDialogue();
                }

            }
            else//In Local Case
            {
                Local();
                if (Input.GetKeyDown(KeyCode.N))
                {
                    audioManager.Stop("Whisper");
                    dialogueTrigger.p_Dmanager.EndDialogue();
                }
            }
        }*/
    }

   /* public void Interactive()
    {
        dialogueTrigger.p_Dmanager.CanNext = dialogueTrigger.p_Dmanager.sentences.Count == 0 ? false : true;
        if (dialogueTrigger.p_Dmanager.OnDialogue && dialogueTrigger.p_Dmanager.CanNext == false && Input.GetKeyUp(KeyCode.Y))
        {
            bargainManager.Type = type.ToString();
            bargainManager.AddBargain(this);
            bargainID = bargainManager.Bargain.Count;
            if (bargainTarget != null)
            {
                bargainManager.Interactive(bargainTarget);
            }
            dialogueTrigger.p_Dmanager.EndDialogue();
            this.gameObject.SetActive(false);
            collided = false;
            audioManager.Stop("Whisper");
        }
    }

    public void Local()
    {
        audioManager.Play("Whisper");
        bargainManager.AddBargain(this);
        bargainTrigger.gameObject.SetActive(true);
        bargainID = bargainManager.Bargain.Count;
        bargainTrigger.GetComponent<LocalTrigger>().ID = bargainID;
        dialogueTrigger.p_Dmanager.CanNext = true;
        if (dialogueTrigger.p_Dmanager.sentences.Count == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            audioManager.Stop("Whisper");
            dialogueTrigger.p_Dmanager.CanNext = false;
            dialogueTrigger.p_Dmanager.EndDialogue();
        }
        this.gameObject.SetActive(false);
        collided = false;
    }*/
}
