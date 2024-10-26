using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Logs : MonoBehaviour
{
    public string logText;
    
    

    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ShowText();
            
            
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.instance.DisableText();

        }
    }
    void ShowText()
    {
        GameManager.instance.ShowText(logText);
    }
    
}
