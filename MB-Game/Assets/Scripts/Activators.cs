using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activators : MonoBehaviour
{
    public List<GameObject> activators;
    public Queue<GameObject> queue;

    void Start()
    {
        activators = new List<GameObject>();
        activators.Clear();
        foreach(GameObject activator in activators)
        {
            queue.Enqueue(activator);
        }
    }
}
