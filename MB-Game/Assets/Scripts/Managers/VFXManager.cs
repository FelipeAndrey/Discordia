using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject[] VFX;
    public Queue<GameObject> Effect;

    void Start()
    {
        Effect = new Queue<GameObject>();
        Effect.Clear();
        foreach (GameObject target in VFX)
        {
            Effect.Enqueue(target);
        }
    }
}
