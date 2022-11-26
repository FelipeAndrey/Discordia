using System.Collections;
using UnityEngine;

public class WoodActive : Interactable
{
    public GameObject lantern, oldPlayerPosition;
    public GameManager manager;
    public Transform spotBrigeCamera;
    public GameObject PlacaExit;

    public PuzzleLabirinto puzzleLabirinto;
    public ParticleSystem Fire1, Fire2;

    [Header("Setting Triggers")]
    public TriggersStructur[] needToSet;

    private void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        lantern = GameObject.FindGameObjectWithTag("Lantern");
        oldPlayerPosition = GameObject.FindGameObjectWithTag("Orientention");
    }
    public override void Interact()
    {
        manager.audioManager.Stop("Pasos");
        Fire1.Play();
        Fire2.Play();
        puzzleLabirinto.wood[puzzleLabirinto.cont].GetComponent<Animator>().SetBool("Up", true);
        puzzleLabirinto.cont++;
        StartCoroutine(CameraBridgeTime());
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

        if (puzzleLabirinto.cont == 3)
        {
            PlacaExit.SetActive(true);
            puzzleLabirinto.LoadAct3.SetActive(true);
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
        lantern.SetActive(false);
        yield return new WaitForSeconds(5f);
        manager.player.canMove = true;
        manager.cameraAtual.GetComponent<Look>().canLook = true;
        manager.cameraAtual.transform.position = oldPlayerPosition.transform.position;
        manager.cameraAtual.transform.rotation = oldPlayerPosition.transform.rotation;
        manager.cameraAtual.GetComponent<CameraFollow>().enabled = true;
        lantern.SetActive(true);
        if (needToSet != null)
        {
            foreach (var set in needToSet)
            {
                if (set.elemento != null)
                {
                    set.elemento.enabled = set.setValueBoxCollider;
                }
                if (set.gameObject != null)
                {
                    set.gameObject.SetActive(set.setValueGameObject);
                }
            }
        }
        yield return null;
    }
}
