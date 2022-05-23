using System.Collections;
using System.Collections.Generic;
using Unity.Rendering;
using UnityEngine;

public class PPManager : MonoBehaviour
{
    public GameObject[] VFX;
    public Queue<GameObject> PP;

    void Start()
    {
        PP = new Queue<GameObject>();
        PP.Clear();
        foreach(GameObject Effect in VFX)
        {
            PP.Enqueue(Effect);
        }
    }
}
