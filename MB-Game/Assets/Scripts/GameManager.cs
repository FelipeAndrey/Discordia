using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [Header("Player")]
    private Moviment player;

    [Header("Camera")]
    public Camera cameraAtual;
    public Camera tradeCamaera;

    [Header("Notas")]
    public List<CardsTrigger> Letters;
    public CanvasGroup cardsGroup;
    [HideInInspector]public Cards Cards;
    private CardsTrigger Card;

    [Header("SavePoint")]
    public Vector3 lastCheckPoint;

    void Start()
    {
        player = GameObject.FindObjectOfType<Moviment>();
        Card = new CardsTrigger();
        cameraAtual = Camera.main;
    }

    void Update()
    {

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

}
