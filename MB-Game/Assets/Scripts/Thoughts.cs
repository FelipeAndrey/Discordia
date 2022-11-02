using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Thoughts : MonoBehaviour
{
    private GameManager manager;

    [Header("Thoughts Settings")]
    [TextArea(1, 3)]
    public string[] thoughts;
    public Queue<string> sentence;
    public TextMeshProUGUI TMP;
    public Animator animatorController;
    private int index = 0;
    [System.NonSerialized] public bool collided, isCalled;

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
        manager = GameObject.FindObjectOfType<GameManager>();
        sentence = new Queue<string>();
        TMP.enabled = false;
    }

    void Update()
    {
        if (collided || isCalled)
        {
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
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
        if (type == ThingType.whenCollider)
        {
            StartThoughts();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collided = false;
    }

    public void StartThoughts()
    {
        isCalled = true;
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
            if (index <= thoughts.Length)
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
        if (notMove)
        {
            manager.player.canMove = true;
            notMove = false;
        }        
    }
}