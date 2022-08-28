using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;

    public CanvasGroup pauseMenuUI;

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
        Time.timeScale = 0f;
        GamePause = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame() 
    {
        print("Saiu do Game...");
        Application.Quit();
    }

    public void SetNewSensitivity(float value) 
    {
        mouseSens.mouseSensitivity = value;
    }
}
