using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : Interactable
{
    public override void Interact()
    {
        SceneManager.LoadScene("End");
        Cursor.lockState = CursorLockMode.None;
    }

}
