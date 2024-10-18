using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public PlayerHealth hp;


    private void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
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
}
