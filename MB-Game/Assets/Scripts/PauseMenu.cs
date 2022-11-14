using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;
    public bool IsNotInGame;

    public CanvasGroup pauseMenuUI;
    public CanvasGroup optionsGame;
    public Look mouseSens;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pauseMenuUI.alpha = 0;
        Time.timeScale = 1f;
        GamePause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        pauseMenuUI.alpha = 1;
        optionsGame.alpha = 0;
        optionsGame.blocksRaycasts = false;
        Time.timeScale = 0f;
        GamePause = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void SetOpitions() 
    {
        pauseMenuUI.alpha = 0;
        optionsGame.blocksRaycasts = true;
        optionsGame.alpha = 1;
    }

    public void SetNewSensitivity(float value)
    {
        mouseSens.mouseSensitivity = value;
    }
}
