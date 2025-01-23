using System.Collections;
using UnityEngine;

public class DialogueTrigger : Interactable
{
    [Header("Dialogue Settings")]
    public DialogueStructure[] Dialogue;
    private DialogueManager p_Dmanager;
    private GameManager p_manager;
    public Camera targetCamera;
    private BoxCollider p_thisObj;
    [SerializeField] private TriggersStructur[] p_needToSet;

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
        p_thisObj = gameObject.GetComponent<BoxCollider>();
        p_Dmanager = GameObject.FindObjectOfType<DialogueManager>();
        p_manager = FindObjectOfType<GameManager>();
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
        if (p_needToSet != null)
        {
            foreach (var set in p_needToSet)
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
        waitTime = p_Dmanager.Time;

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

            if (p_thisObj == null)
                return;

            p_thisObj.enabled = false;

            if (p_needToSet != null)
            {
                foreach (var set in p_needToSet)
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
            p_manager.SetMoving(false);
            p_manager.audioManager.Stop("Pasos");
        }

        if (activeAnimation && parameter != null)
            p_Dmanager.Manager.animator.SetBool(parameter, true);

        if (thoughts != null)
            p_Dmanager.p_thoughts = thoughts;

        p_Dmanager.CanNext = nextDialogue;
        p_Dmanager.Dialogue(value, Dialogue, this.gameObject, waitForThoughts);

        if (som != null)
            som.Play(nomeSom);

    }

    IEnumerator AfterEvent(float value)
    {
        yield return new WaitForSeconds(value + 2f);
        TriggerDialogue(true);
        p_Dmanager.Time = 0f;
        yield return null;
    }

    public void Zoom()
    {
        if (transformRef == null)
            return;
        if (sprite == null)
            return;

        if (temp < 1.0f && p_Dmanager.OnDialogue)
        {
            temp += Time.deltaTime * 0.5f;
            p_Dmanager.Manager.cameraAtual.GetComponent<Look>().canLook = false;
            p_Dmanager.Manager.cameraAtual.transform.LookAt(transformRef);
            p_Dmanager.Manager.cameraAtual.fieldOfView = Mathf.Lerp(60, valueOfView, temp);
        }
        else if (!p_Dmanager.OnDialogue && temp > 0f)
        {
            temp -= Time.deltaTime * 0.5f;
            p_Dmanager.Manager.cameraAtual.GetComponent<Look>().canLook = true;
            p_Dmanager.Manager.cameraAtual.fieldOfView = Mathf.Lerp(60, valueOfView, temp);
            StartCoroutine(SpriteFadeOut());
        }
        else if (!p_Dmanager.OnDialogue && temp < 0f)
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
        p_Dmanager.Manager.audioManager.Stop("Pasos");
    }

    private void OnTriggerExit(Collider other)
    {
        collided = false;
    }
    #endregion
}
