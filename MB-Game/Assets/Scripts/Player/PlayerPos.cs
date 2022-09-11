using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();

    }


    void FixedUpdate()
    {
        //NewSavePosition();
    }
    private void NewSavePosition()
    {
         transform.position = gameManager.lastCheckPoint;
    }
}
