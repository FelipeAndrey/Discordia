using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneTrigger : MonoBehaviour
{
    private GameManager manager;
    public string level;
    public GameObject door;

    private void Start()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.LoadLevel(level);
            if (door == null)
                return;
            door.SetActive(false);
        } 
    }
}
