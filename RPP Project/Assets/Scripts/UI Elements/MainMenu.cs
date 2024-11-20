using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        AudioObserver.OnPlaySfxEvent("button");
        SceneManager.LoadScene("TestScene");
        GameManager.instance.hp.SetupHealth();
        GameManager.instance.healthBar.SetActive(true);
        GameManager.instance.ammoTxt.SetActive(true);
    }

    public void QuitGame()
    {
        AudioObserver.OnPlaySfxEvent("button");
        Application.Quit();
    }
}
