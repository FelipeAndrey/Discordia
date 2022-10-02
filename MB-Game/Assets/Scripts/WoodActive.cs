using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodActive : Interactable
{
    public PuzzleLabirinto puzzleLabirinto;
    public ParticleSystem Fire;
    
    public override void Interact()
    {
        puzzleLabirinto.wood[puzzleLabirinto.cont].SetActive(true);
        puzzleLabirinto.cont++;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Fire.Play();
        if (puzzleLabirinto.cont == 3)
        {
            puzzleLabirinto.invisibleWall.enabled = false;
        }

    }

    public void CameraBridgeWood() 
    {
        //puzzleLabirinto.manager.TradeCamera();
    }
}
