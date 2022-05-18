using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public CameraManager cameraManager;
    public PlayerManager playerManager;
    private bool onDialogue;

    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if (onDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentence();
            }
        }
    }

    public void Dialogue(bool value, DialogueStructure dialogue)
    {
        this.gameObject.SetActive(value);
        if (value)
        {
            onDialogue = true;
            StartDialogue(dialogue);
            playerManager.SetWalk(false);
        }
        else
        {
            EndDialogue();
        }
    }

    public void StartDialogue(DialogueStructure dialogue)
    {
        Debug.Log("Iniciando conversa com: " + dialogue.name);
        sentences.Clear();

        foreach(string sentence in dialogue.sentence)
        {
            sentences.Enqueue(sentence);
        }

        NextSentence();
    }

    public void NextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string displaySentence = sentences.Dequeue();
        Debug.Log(displaySentence);
    }

    public void EndDialogue()
    {
        Debug.Log("Encerrou o dialogo");
        onDialogue = false;
        playerManager.SetWalk(true);

        if (cameraManager.CameraTarget != null)
            ActiveCameraTrade(false);
    }

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
    #endregion
}
