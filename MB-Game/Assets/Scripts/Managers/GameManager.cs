using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]
    private DialogueManager p_dialogueManager;
    private AudioManager p_audioManager;

    [Header("Player")]
    public Player player;
    public Animator animator;

    [Header("Camera")]
    public Camera cameraAtual;
    public Camera tradeCamaera;

    [Header("Notas")]
    public List<CardsTrigger> Letters;
    public CanvasGroup cardsGroup;
    [HideInInspector] public Cards Cards;
    private CardsTrigger Card;

    [Header("aaaaaaaa")]
    public int puzzleValueFinal;
    public bool turOffAnimation;



    void Start()
    {
        p_dialogueManager = FindObjectOfType<DialogueManager>();
        p_audioManager = FindObjectOfType<AudioManager>();
        if (!turOffAnimation)
        {
            Card = new CardsTrigger();
            cameraAtual.GetComponent<Look>().canLook = false;
            player.CanMove = false;
            animator.SetBool("isAwaking", true);
        }

    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0) && animator.GetBool("isAwaking") == true)
        {
            animator.SetBool("isAwaking", false);
            cameraAtual.GetComponent<Look>().canLook = true;
        }
    }

    public Camera GetCamera()
    {
        return cameraAtual;
    }

    public void Letter(bool reading)
    {
        if (reading)
        {
            foreach (var item in Letters)
            {
                if (item.properts.id.Equals(Cards.CallCardsTrigger()))
                {
                    Card = item;
                    item.gameObject.SetActive(true);
                    item.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = item.properts.text;
                }
            }
            cardsGroup.alpha = 1;
        }
        else
        {
            cardsGroup.alpha = 0;
            Card.gameObject.SetActive(false);
        }
    }

    public void Breathing()
    {
        //Animator.enabled = !player.isMoving;
    }

    public void SetMoving(bool value)
    {
        player.CanMove = value;
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
    }

    #region Get & Set
    public AudioManager audioManager { get => p_audioManager; }
    public DialogueManager dialogueManager { get => p_dialogueManager; }
    #endregion
}
