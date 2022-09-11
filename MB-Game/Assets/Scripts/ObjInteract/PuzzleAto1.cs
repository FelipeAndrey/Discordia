using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using static UnityEditor.Progress;

public class PuzzleAto1 : Interactable
{
    private GameManager manager;

    public PuzzleTrigger trigger;

    public override void Interact()
    {
        if (manager.player.lantern == null)
            return;
        else if (manager.player.lantern.luzAtiva == true)
        {
            RemoveGoodWord();
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
        if (trigger.puzzleInteract.Count == 0)
        {
            //Destroy(door);
        }
    }

    public void RemoveGoodWord()
    {
        if (trigger.puzzleInteract.Contains(this.gameObject))
        {
            trigger.puzzleInteract.Remove(gameObject);
            Destroy(gameObject);
        }

    }
}

