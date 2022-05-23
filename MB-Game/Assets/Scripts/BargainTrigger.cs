using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BargainTrigger : MonoBehaviour
{
    [Header("Controlado da barganha")]
    public BargainManager manager;

    public enum TriggerCategory { Interactive, Local }
    public TriggerCategory BargainCategory;
    public enum Type { Camera, Behavior, VFX, HUD };
    public Type BargainType;
    public Collider ColliderTarget;
    private int bargainIndex;

    private void Start()
    {
        bargainIndex = manager.Bargains.IndexOf(this);
    }

    #region OnTriggers
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (BargainCategory == TriggerCategory.Interactive)
            {
                manager.StartBargain(bargainIndex, TriggerCategory.Interactive, BargainType.ToString());
            }
            else
            {
                manager.StartBargain(bargainIndex, TriggerCategory.Local, BargainType.ToString());
            }
        }
    }
    #endregion
}
