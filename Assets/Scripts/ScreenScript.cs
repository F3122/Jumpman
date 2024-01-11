using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScreenScript : MonoBehaviour
{
    public GameObject loseGame;
    public GameObject player;
    public static bool alive = true;
    
    
    void Start()
    {
        loseGame.SetActive(false);
        alive = true;
    }

    void Update()
    {

        alive = player.GetComponent<ThirdPersonMovement>().alive;
        //Debug.Log(alive);
        
        if (!alive)
        {
            loseGame.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
        
    }
}
