using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    [Header("Atributos para o Diálogo")]
    private GameManager p_manager;
    [SerializeField] private GameObject p_dialogueCanvas;
    public TextMeshProUGUI TMPName;
    public TextMeshProUGUI TMPSentence;
    public Queue<string> sentences;
    private int p_index;
    [HideInInspector]
    private DialogueStructure[] p_structureArray;
    private GameObject p_target;
    public Thoughts p_thoughts;
    private float p_waitForThoughts;



    void Start()
    {
        sentences = new Queue<string>();
        p_dialogueCanvas.SetActive(false);
        p_manager = gameObject.GetComponent<GameManager>();
    }

    void Update()
    {

        if (OnDialogue && CanNext)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentence();
            }
        }
    }

    public void Dialogue(bool value, DialogueStructure[] dialogues, GameObject objectTarget, float waitForThoughtsTarget)
    {
        p_target = objectTarget;
        p_waitForThoughts = waitForThoughtsTarget;
        p_index = 0;
        p_structureArray = dialogues;
        this.gameObject.SetActive(value);
        OnDialogue = true;
        StartDialogue(p_structureArray[0]);

    }

    public void StartDialogue(DialogueStructure dialogue)
    {
        p_dialogueCanvas.SetActive(OnDialogue);
        TMPName.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentence)
        {
            sentences.Enqueue(sentence);
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            p_index++;
            if (p_index >= p_structureArray.Length)
            {
                EndDialogue();
                return;
            }
            StartDialogue(p_structureArray[p_index]);
            return;
        }
        string displaySentence = sentences.Dequeue();
        TMPSentence.text = displaySentence;
    }

    public void EndDialogue()
    {
        OnDialogue = false;
        p_dialogueCanvas.SetActive(OnDialogue);
        //target.gameObject.GetComponent<DialogueTrigger>().enabled = onDialogue;

        if (p_manager.player.CanMove == false)
        {
            p_manager.SetMoving(true);
        }
        if (p_thoughts != null && p_waitForThoughts == 0)
        {
            p_thoughts.StartThoughts();
        }
        else
        {
            StartCoroutine(CallEvent(p_waitForThoughts));
        }
    }

    private IEnumerator CallEvent(float value)
    {
        yield return new WaitForSeconds(value);
        if (p_thoughts != null)
            p_thoughts.StartThoughts();
        yield return null;
    }

    #region Get & Set
    public bool OnDialogue { get; set; } = false;
    public bool CanNext { get; set; } = false;
    public float Time { get; set; }
    public GameManager Manager { get => p_manager; }
    #endregion
}
