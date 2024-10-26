using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        int sceneIndex = GameManager.instance.sceneIndex;
        GameManager.instance.sceneIndex = -1;
        GameManager.instance.hp.SetupHealth();
        if (sceneIndex >= 0)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError("Nenhuma fase foi salva.");
            SceneManager.LoadScene(0);
        }
        
        // string lastLevel = PlayerPrefs.GetString("LastLevel");
        //
        // if (!string.IsNullOrEmpty(lastLevel))
        // {
        //     SceneManager.LoadScene(lastLevel);
        // }
        // else
        // {
        //     Debug.LogError("Nenhuma fase foi salva.");
        // }
    }
}
