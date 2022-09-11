using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : Interactable
{
    private GameManager manager;

    public List<GameObject> puzzleInteract;

    public override void Interact()
    {
        this.gameObject.SetActive(false);
        TriggerPuzzle();
    }
    // Start is called before the first frame update
    void Start()
    {
        //puzzleInteract = new List<GameObject>();
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerPuzzle()
    {
        for (int i = 0; i < puzzleInteract.Count; i++)
        {
            puzzleInteract[i].SetActive(true);
        }
    }
}

