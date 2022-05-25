using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBargainTrigger : MonoBehaviour
{
    public BargainManager bargainManager;
    public GameObject bargainTarget;
    private bool collided;
    public int ID { get; set; }
    private void Update()
    {
        if (collided)
        {
            foreach(Bargain target in bargainManager.Bargain)
            {
                if (target.bargainID == ID)
                {
                    bargainManager.Type = target.type.ToString();
                    bargainManager.Local(bargainTarget);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
    }
}
