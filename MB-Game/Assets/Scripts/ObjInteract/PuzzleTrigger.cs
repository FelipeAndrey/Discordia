using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : Interactable
{
    private GameManager manager;

    public GameObject Words;
    public GameObject door;
    public List<GameObject> puzzleInteract;

    private bool puzzleSpawn;

    public override void Interact()
    {
        if (manager.player.lantern == null)
            return;
        else if (manager.player.lantern.luzAtiva == true)
        {
            if (!puzzleSpawn)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                Words.SetActive(true);
                //TriggerPuzzle();
                puzzleSpawn = true;
            }
        }
        else
            return;

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
        if (puzzleInteract.Count == 3)
        {
            Words.SetActive(false);
            puzzleSpawn = false;
            Destroy(door);
        }
    }

    public void TriggerPuzzle()
    {

    }
}

