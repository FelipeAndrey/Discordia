using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainManager : MonoBehaviour
{
    [Header("Controladores da cena")]
    public DialogueManager DialogueManager;
    public PlayerManager PlayerManager;
    public CameraManager CameraManager;
    public PPManager PPManager;
    [Header("Lista de barganhas da cena")]
    public List<BargainTrigger> Bargains;

    //Privates
    private Collider colliderTarget;
    private int bargainActivated { get; set; }


    public void StartBargain(int bargainIndex, BargainTrigger.TriggerCategory Category, string Type)
    {
        bargainActivated = bargainIndex;
        switch (Category)
        {
            case BargainTrigger.TriggerCategory.Local:
                Local(Type);
                break;

            case BargainTrigger.TriggerCategory.Interactive:
                Interactive(Type);
                break;
        }
    }

    public void Local(string value) 
    {
        if(Bargains[bargainActivated].ColliderTarget != null)
        {
            colliderTarget = Bargains[bargainActivated].ColliderTarget;
        }
        
        switch (value)
        {
            case "Camera":
                break;
            case "Behaivor":
                break;
            case "VFX":
                GameObject PPTarget = PPManager.PP.Dequeue();
                if (colliderTarget.isTrigger)
                {
                    PPTarget.gameObject.SetActive(false);
                }
                break;
            case "HUD":
                break;
        }
    }

    public void Interactive(string value)
    {
        switch (value)
        {
            case "Camera":
                break;
            case "Behaivor":
                break;
            case "VFX":
                break;
            case "HUD":
                break;
        }
    }
}
