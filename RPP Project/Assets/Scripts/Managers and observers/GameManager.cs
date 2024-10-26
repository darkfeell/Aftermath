using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    
    public PlayerHealth hp;
    public PlayerMovement playerMove;
    public PlayerShooting playerShoot;
    

    public int sceneIndex;
    public TextMeshProUGUI textBoxText;
    public GameObject textBox;

    private void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        sceneIndex = -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        TryGetComponent(out hp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveLastLevel()
    {

        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastLevel", currentScene);
        PlayerPrefs.Save();  

        
        
    }
    public void ShowText(string text)
    {
        textBox.SetActive(true);
        textBoxText.text = text;
    }
    public void DisableText()
    {
        textBox.SetActive(false);
    }
    public void SetMovScript(PlayerMovement playerMovScript)
    {
        playerMove = playerMovScript;
    }
    public void SetShootScript(PlayerShooting playerShootScript)
    {
        playerShoot = playerShootScript;
    }
}
