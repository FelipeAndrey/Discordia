using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Thoughts : MonoBehaviour
{
    public GameManager manager;

    [Header("Thoughts Settigns")]
    [TextArea(1, 3)]
    public string[] thoughts;
    public Queue<string> sentence;
    public TextMeshProUGUI TMP;
    public Animator animatorController;
    private int index = 0;

    [Header("Thoughts Type")]
    public ThingType type;
    public enum ThingType
    {
        whenCollider,
        whenCall
    }

    [Header("Set Player")]
    public bool notMove;

    void Start()
    {
        sentence = new Queue<string>();
        TMP.enabled = false;
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (type == ThingType.whenCollider)
        {
            StartThoughts();
        }
    }

    public void StartThoughts()
    {
        print("Startou Pensamento");
        TMP.enabled = true;
        foreach (var think in thoughts)
        {
            print("Entrou o: " + think);
            sentence.Enqueue(think);
        }

        if (notMove)
        {
            manager.player.canMove = false;
        }

        NextThinking();
    }

    private void NextThinking() 
    {
        if(sentence.Count == 0)
        {
            index++;
            if(index == thoughts.Length - 1)
            {
                EndThoughts();
                return;
            }
            return;
        }

        string displaySentence = sentence.Dequeue();
        print("Saiu o: " + displaySentence);
        TMP.text = displaySentence;

        CallAnimation();
    }

    private void CallAnimation()
    {
        print("Chamou Animação");
        animatorController.SetBool("isThinking", true);
    }

    private void EndThoughts()
    {
        print("Entrou no sair");
        animatorController.SetBool("isThinking", false);
        this.gameObject.SetActive(false);
        manager.player.canMove = true;
    }
}