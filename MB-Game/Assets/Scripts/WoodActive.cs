using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class WoodActive : Interactable
{
    public GameManager manager;
    public Transform spotBrigeCamera, oldPlayerPosition;

    public PuzzleLabirinto puzzleLabirinto;
    public ParticleSystem Fire;

    
    public override void Interact()
    {
        Fire.Play();
        puzzleLabirinto.wood[puzzleLabirinto.cont].SetActive(true);
        puzzleLabirinto.cont++;
        StartCoroutine(CameraBridgeTime());
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
  
        if (puzzleLabirinto.cont == 3)
        {
            puzzleLabirinto.invisibleWall.enabled = false;
        }

    }

    IEnumerator CameraBridgeTime() 
    {
        manager.cameraAtual.GetComponent<Look>().canLook = false;
        manager.player.canMove = false;
        manager.cameraAtual.transform.position = spotBrigeCamera.position;
        manager.cameraAtual.transform.rotation = spotBrigeCamera.rotation;
        manager.cameraAtual.GetComponent<CameraFollow>().enabled = false;
        yield return new WaitForSeconds(5f);
        manager.player.canMove = true;
        manager.cameraAtual.GetComponent<Look>().canLook = true;
        manager.cameraAtual.transform.position = oldPlayerPosition.transform.position;
        manager.cameraAtual.transform.rotation = oldPlayerPosition.transform.rotation;
        manager.cameraAtual.GetComponent<CameraFollow>().enabled = true;
        yield return null;
    }
}
