using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    void Start(){
        GameManager.instance.healthBar.SetActive(false);
        GameManager.instance.ammoTxt.SetActive(false);
        //GameManager.instance.bossHealthBar.SetActive(false);
    }
    public void LoadMenu()
    {
        AudioObserver.OnPlaySfxEvent("button");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        AudioObserver.OnPlaySfxEvent("button");
        int sceneIndex = GameManager.instance.sceneIndex;
        GameManager.instance.sceneIndex = -1;
        GameManager.instance.hp.SetupHealth();
        GameManager.instance.healthBar.SetActive(true);
        GameManager.instance.ammoTxt.SetActive(true);
        
        
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
