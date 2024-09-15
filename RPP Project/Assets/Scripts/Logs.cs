using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Logs : MonoBehaviour
{
    public string logText;
    public GameObject textBox;
    public TextMeshProUGUI textComponent;
    
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
            textBox.SetActive(false);

        }
    }
    void ShowText()
    {
        textBox.SetActive(true);
        textComponent.text = logText;
    }
    
}
