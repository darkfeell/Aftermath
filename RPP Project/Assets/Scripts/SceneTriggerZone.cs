using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTriggerZone : MonoBehaviour
{
    public int batteriesNecessary;
    public string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(batteriesNecessary == GameManager.instance.playerMove.batteriesCollected && col.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (batteriesNecessary == GameManager.instance.playerMove.batteriesCollected && col.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
