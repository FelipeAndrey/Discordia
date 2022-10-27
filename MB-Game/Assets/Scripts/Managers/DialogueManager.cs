using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [Header("Atributos para o Diálogo")]
    public GameManager Manager;
    public GameObject dialogueCanvas;
    public TextMeshProUGUI TMPName;
    public TextMeshProUGUI TMPSentence;
    public Queue<string> sentences;
    private int index;
    private DialogueStructure[] structureArray;
    private GameObject target;
    /*[System.NonSerialized]*/
    public Thoughts thoughts;
    private float waitForThoughts;
    public bool onDialogue { get; set; } = false;
    public bool canNext { get; set; } = false;
    public float time { get; set; }


    void Start()
    {
        sentences = new Queue<string>();
        dialogueCanvas.SetActive(false);
        Manager = gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        if (onDialogue && canNext)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentence();
            }
        }
    }

    public void Dialogue(bool value, DialogueStructure[] dialogues, GameObject objectTarget, float waitForThoughtsTarget)
    {
        target = objectTarget;
        waitForThoughts = waitForThoughtsTarget;
        index = 0;
        structureArray = dialogues;
        this.gameObject.SetActive(value);
        onDialogue = true;
        StartDialogue(structureArray[0]);
    }

    public void StartDialogue(DialogueStructure dialogue)
    {
        dialogueCanvas.SetActive(onDialogue);
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
            index++;
            if (index >= structureArray.Length)
            {
                EndDialogue();
                return;
            }
            StartDialogue(structureArray[index]);
            return;
        }
        string displaySentence = sentences.Dequeue();
        TMPSentence.text = displaySentence;
    }

    public void EndDialogue()
    {
        onDialogue = false;
        dialogueCanvas.SetActive(onDialogue);
        target.gameObject.GetComponent<DialogueTrigger>().enabled = onDialogue;

        if (Manager.player.canMove == false)
        {
            Manager.SetMoving(true);
        }
        if (thoughts != null && waitForThoughts == 0)
        {
            thoughts.StartThoughts();
        }
        else
        {
            StartCoroutine(CallEvent(waitForThoughts));
        }
    }

    private IEnumerator CallEvent(float value)
    {
        yield return new WaitForSeconds(value);
        if (thoughts != null)
            thoughts.StartThoughts();
        yield return null;
    }

}
