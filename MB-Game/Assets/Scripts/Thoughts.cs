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
    public float speed = 1f;
    public float betweenSentence = 0f;
    public TextMeshProUGUI TMP;
    public Animator animatorController;

    [Header("Thoughts Type")]
    public ThingType type;
    public enum ThingType
    {
        whenCollider,
        whenCall
    }

    [Header("In Call Case")]
    public GameObject trigger;

    [Header("Set Player")]
    public bool notMove;

    void Start()
    {
        sentence = new Queue<string>();
        TMP.enabled = false;
        speed = animatorController.speed;
        if(type == ThingType.whenCall)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void Update()
    {
        if(type == ThingType.whenCall && !trigger.activeSelf)
        {
            print("entrou");
            GetComponent<BoxCollider>().enabled = true;
            StartThoughts();
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
        if(sentence.Count == 0)
        {
            EndThoughts();
        }

        string displaySentence = sentence.Dequeue();
        TMP.text = displaySentence;

        CallAnimation();
    }

    private void CallAnimation()
    {
        animatorController.SetBool("isThinking", true);
        if(animatorController.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animatorController.IsInTransition(0) && betweenSentence <= 0.1)
        {
            animatorController.SetBool("isThinking", false);
        }
        else
        {
            StartCoroutine(WaitBetweenSentence(betweenSentence));
        }
    }

    private IEnumerator WaitBetweenSentence(float value)
    {
        animatorController.SetBool("isThinking", false);
        yield return new WaitForSeconds(value);
        CallAnimation();
        yield return null;
    }

    private void EndThoughts()
    {
        this.gameObject.SetActive(false);
        manager.player.canMove = true;
    }
}