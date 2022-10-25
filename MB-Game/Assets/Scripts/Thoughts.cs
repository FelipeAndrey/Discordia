using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        TMP.enabled = true;
        foreach (var think in thoughts)
        {
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
        if (sentence.Count == 0)
        {
            if (index == thoughts.Length - 1)
            {
                EndThoughts();
                return;
            }
            index++;
            return;
        }

        string displaySentence = sentence.Dequeue();
        TMP.text = displaySentence;

        CallAnimation();
    }

    private void CallAnimation()
    {
        animatorController.SetBool("isThinking", true);
    }

    private void EndThoughts()
    {
        animatorController.SetBool("isThinking", false);
        this.gameObject.SetActive(false);
        manager.player.canMove = true;
    }
}