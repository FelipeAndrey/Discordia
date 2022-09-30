using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodActive : Interactable
{
    public PuzzleLabirinto puzzleLabirinto;
    
    public override void Interact()
    {
        puzzleLabirinto.wood[puzzleLabirinto.cont].SetActive(true);
        puzzleLabirinto.cont++;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        if (puzzleLabirinto.cont == 3)
        {
            puzzleLabirinto.invisibleWall.enabled = false;
        }
        puzzleLabirinto.manager.TradeCamera();
    }

    public void CameraBridgeWood() 
    {
        //puzzleLabirinto.manager.TradeCamera();
    }
}
