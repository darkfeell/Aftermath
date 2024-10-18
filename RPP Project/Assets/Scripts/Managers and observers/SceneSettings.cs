using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSettings : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
