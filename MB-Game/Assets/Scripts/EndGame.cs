using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : Interactable
{
    public override void Interact()
    {
        SceneManager.LoadScene("Main Menu");
        Cursor.lockState = CursorLockMode.None;
    }

}
