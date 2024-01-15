using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
