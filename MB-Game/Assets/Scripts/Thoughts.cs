using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Thoughts : MonoBehaviour
{
    public GameManager manager;

    [Header("Thoughts Settings")]
    [TextArea(1, 3)]
    public string[] thoughts;
    public Queue<string> sentence;
    public TextMeshProUGUI TMP;
    public Animator animatorController;
    private int index = 0;

    [Header("Thoughts Type")]
    public ThingType type;

    [Header("Setting Triggers")]
    public TriggersStructur[] needToSet;

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

    void Update()
    {
        if (needToSet != null)
        {
            foreach (var set in needToSet)
            {
                if (set != null)
                    set.elemento.enabled = set.setValue;
            }
        }
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
            if (index == thoughts.Length - 2)
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