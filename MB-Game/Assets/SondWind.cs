using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SondWind : MonoBehaviour
{
    [Header("Som")]
    public string nomeSom;
    private AudioManager som;

    // Start is called before the first frame update
    void Start()
    {
        som = GameObject.FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        som.Play(nomeSom);
    }
    private void OnTriggerExit(Collider other)
    {
        som.Stop(nomeSom);
    }
}
