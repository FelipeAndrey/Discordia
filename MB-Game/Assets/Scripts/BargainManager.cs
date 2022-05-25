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
    private int Index { get; set; } = 0;
    private List<Activators> Activators;

    void Start()
    {
        foreach(BargainTrigger trigger in Bargains)
        {
            trigger.gameObject.SetActive(false);
        }
        Bargains[Index].gameObject.SetActive(true);
    }

    public void StartBargain(int bargainIndex, BargainTrigger.TriggerCategory Category, string Type)
    {
        Index = bargainIndex;
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
        switch (value)
        {
            case "Camera":
                break;
            case "Behaivor":
                break;
            case "VFX":
                GameObject PPTarget = PPManager.PP.Dequeue();
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
