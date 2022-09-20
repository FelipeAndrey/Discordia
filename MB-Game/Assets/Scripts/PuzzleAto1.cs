using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.Mathematics;
using UnityEngine;

public class PuzzleAto1 : Interactable
{
    private GameManager manager;
    public PuzzleTrigger trigger;

    private int puzzleValue;

    public override void Interact()
    {
        if (manager.player.lantern == null)
            return;
        else if (manager.player.lantern.luzAtiva == true)
        {
            RemoveWord();
            print(puzzleValue);
        }
        else
            return;
        
    }

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {

    }

    public void RemoveWord()
    {
        if (trigger.puzzleInteract.Contains(this.gameObject))
        {
            if (gameObject.CompareTag("godWord"))
            {
                puzzleValue = UnityEngine.Random.Range(1, 10);
                manager.puzzleValueFinal += puzzleValue;
                
            }
            else if (gameObject.CompareTag("badWord"))
            {
                puzzleValue = UnityEngine.Random.Range(-5,0);
                manager.puzzleValueFinal += puzzleValue;
            }

            trigger.puzzleInteract.Remove(gameObject);
            Destroy(gameObject);
        }

    }
}

