using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class BargainManager : MonoBehaviour
{
    public PlayerManager playerManager;
    public CameraManager cameraManager;
    public VFXManager vFXManager;
    public CanvasManager canvasManager;
    public AudioManager audioManager;
    //[System.NonSerialized] 
    public List<Bargain> Bargain;
    public string Type { get; set; }

    public void AddBargain(Bargain target)
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
                target.gameObject.GetComponent<PlayerManager>().SetSpeed(40f);
                audioManager.Pitch("PlayerWalk", 1.5f);
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
                GameObject HoH = GameObject.Find("Hidden Object Holder");
                HoH.SetActive(false);
                break;
            case "Camera":
                break;
        }
    }
}
