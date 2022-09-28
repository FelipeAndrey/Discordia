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
    public bool onDialogue { get; set; } = false;
    public bool canNext { get; set; } = false;


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

    public void Dialogue(bool value, DialogueStructure [] dialogues)
    {
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
        if (Manager.player.canMove == false)
        {
            Manager.player.canMove = true;
        }
        onDialogue = false;
        dialogueCanvas.SetActive(onDialogue);

        //Aqui ira a logica do Pensamento

        /*if (cameraManager.CameraTarget != null)
        {
            ActiveCameraTrade(false);
        }*/
    }
    /*
    #region Trade Camera On/Off
    /// <summary>
    /// ActiveCameraTrade: Ativa ou desativa a troca de câmera.
    /// </summary>
    /// <returns>Recebe um valor: <c>True ou False</c></returns>
    public void ActiveCameraTrade(bool value)
    {
        cameraManager.Trade(value);
    }
    /// <summary>
    /// TargetCameraTrade: Referencia a câmera alvo para troca de cena.
    /// </summary>
    /// <returns>Recebe um valor do tipo: <c>Camera</c></returns>
    public void TargetCameraTrade(Camera target)
    {
        cameraManager.CameraTarget = target;
    }
    #endregion*/
}
