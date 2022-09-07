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
        AAAA();
    }
    private void AAAA()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position = gameManager.lastCheckPoint;
        }
    }
}
