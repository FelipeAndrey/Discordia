using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainManager : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public CameraManager CameraManager;
    public VFXManager VFXManager;
    public CanvasManager CanvasManager;
    //[System.NonSerialized] 
    public List<Bargain> Bargain;
    public string Type { get; set; }

    public void StartBargain(Bargain target)
    {
        Bargain.Add(target);
    }

    public void Local(GameObject target)
    {
        switch (Type)
        {
            case "HUD":
                break;
            case "Behavior":
                target.gameObject.GetComponent<PlayerManager>().SetSpeed(60f);
                break;
            case "VFX":
                target.gameObject.SetActive(false);
                break;
            case "Camera":
                break;
        }
    }

    public void Interactive(GameObject target)
    {
        switch (Type)
        {
            case "HUD":
                break;
            case "Behavior":
                break;
            case "VFX":
                target.gameObject.SetActive(false);
                break;
            case "Camera":
                break;
        }
    }
}
