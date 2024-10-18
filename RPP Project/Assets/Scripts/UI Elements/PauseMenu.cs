using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
