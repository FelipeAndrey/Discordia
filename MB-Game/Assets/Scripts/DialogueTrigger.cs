using System.Collections;
using UnityEngine;

public class DialogueTrigger : Interactable
{
    [Header("Dialogue Settings")]
    public DialogueStructure[] dialogue;
    public DialogueManager manager;
    public Camera targetCamera;
    public BoxCollider thisObj;
    public TriggersStructur[] needToSet;

    [Header("Automatic Dialogue")]
    public bool nextDialogue;
    public bool autoDialogue;

    [Header("Set Player")]
    public bool notMove;

    [Header("Have Animation")]
    public float waitTime = 0f;
    public bool activeAnimation;
    public string parameter;

    [Header("Have Thoughts")]
    public Thoughts thoughts;
    public float waitForThoughts = 0f;

    [Header("Final Level")]
    public bool isDialogueToFinal;
    public GameObject doorOne, doorTwo;

    [Header("Zoom")]
    public Transform transformRef;
    public float valueOfView;
    private float temp = 0;
    private bool zoom = false;
    public SpriteRenderer sprite;
    public float fadeOutTime;
    private Color color;

    [Header("Som")]
    public string nomeSom;
    private AudioManager som;


    [System.NonSerialized] public bool collided;

    private void Start()
    {
        thisObj = gameObject.GetComponent<BoxCollider>();
        manager = GameObject.FindObjectOfType<DialogueManager>();
        som = GameObject.FindObjectOfType<AudioManager>();
    }

    public override void Interact()
    {
        if (waitTime > 0)
        {
            StartCoroutine(AfterEvent(waitTime));
        }
        TriggerDialogue(true);

        if (doorOne == null && doorTwo == null)
            return;
        else if (isDialogueToFinal)
        {
            doorOne.SetActive(false);
        }
        if (needToSet != null)
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

    void Update()
    {
        waitTime = manager.time;

        if (zoom)
        {
            Zoom();
        }

        if (collided && autoDialogue)
        {

            if (waitTime > 0)
            {
                StartCoroutine(AfterEvent(waitTime));
            }

            TriggerDialogue(true);

            if (thisObj == null)
                return;

            thisObj.enabled = false;

            if (needToSet != null)
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

            collided = false;
        }
    }

    public void TriggerDialogue(bool value)
    {

        if (notMove == true)
        {
            manager.Manager.SetMoving(false);
            manager.Manager.audioManager.Stop("Pasos");
        }

        if (activeAnimation && parameter != null)
            manager.Manager.animator.SetBool(parameter, true);

        if (thoughts != null)
            manager.thoughts = thoughts;

        manager.canNext = nextDialogue;
        manager.Dialogue(value, dialogue, this.gameObject, waitForThoughts);

        if (som != null)
            som.Play(nomeSom);

    }

    IEnumerator AfterEvent(float value)
    {
        yield return new WaitForSeconds(value + 2f);
        TriggerDialogue(true);
        manager.time = 0f;
        yield return null;
    }

    public void Zoom()
    {
        if (transformRef == null)
            return;
        if (sprite == null)
            return;

        if (temp < 1.0f && manager.onDialogue)
        {
            temp += Time.deltaTime * 0.5f;
            manager.Manager.cameraAtual.GetComponent<Look>().canLook = false;
            manager.Manager.cameraAtual.transform.LookAt(transformRef);
            manager.Manager.cameraAtual.fieldOfView = Mathf.Lerp(60, valueOfView, temp);
        }
        else if (!manager.onDialogue && temp > 0f)
        {
            temp -= Time.deltaTime * 0.5f;
            manager.Manager.cameraAtual.GetComponent<Look>().canLook = true;
            manager.Manager.cameraAtual.fieldOfView = Mathf.Lerp(60, valueOfView, temp);
            StartCoroutine(SpriteFadeOut());
        }
        else if (!manager.onDialogue && temp < 0f)
        {
            this.gameObject.SetActive(false);
        }

    }
    IEnumerator SpriteFadeOut() 
    {
        while (color.a > 0f)
        {
            print("entrou");
            color.a -= Time.deltaTime / fadeOutTime;
            sprite.color = color;
            if (color.a <= 0f)
            {
                color.a = 0.0f;
            }
            yield return null;
        }
        sprite.color = color;
    }

    #region OnTriggers
    private void OnTriggerEnter(Collider other)
    {
        collided = true;
        zoom = true;
       
        if (doorOne == null || doorTwo == null)
            return;
        else if (isDialogueToFinal)
        {
            doorOne.SetActive(false);
            doorTwo.SetActive(false);
        }
        manager.Manager.audioManager.Stop("Pasos");
    }

    private void OnTriggerExit(Collider other)
    {
        collided = false;
    }
    #endregion
}
