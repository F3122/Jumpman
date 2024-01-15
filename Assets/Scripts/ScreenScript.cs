using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScreenScript : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject gameWon;
    public GameObject gamePaused;
    
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bestTimeText;
    
    public GameObject player;
    public static bool alive = true;
    public static bool won = false;
    
    public static bool paused = false;
    
    void Start()
    {
        gameOver.SetActive(false);
        gameWon.SetActive(false);
        gamePaused.SetActive(false);

        Time.timeScale = 1f;
        paused = false;

        alive = true;
        won = false;
    }

    void Update()
    {
        alive = player.GetComponent<ThirdPersonMovement>().alive;
        won = player.GetComponent<ThirdPersonMovement>().won;

        //Debug.Log(alive);
    
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (!alive)
        {
            FinishGame();
        }
        else if (won)
        {
            GameWon();
        }
    }
    
    public void PauseGame()
    {
        paused = true;
        gamePaused.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1f;
        gamePaused.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void FinishGame()
    {
        paused = true;
        gameOver.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
    
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Riavvio scena");
    }
    
    void CheckBestTime()
    {
        if (TimeCounter.time < PlayerPrefs.GetFloat("Time"))
        {
            Debug.Log("record fatto");
            PlayerPrefs.SetFloat("Time", TimeCounter.time);
        }
    }
    public void GameWon() 
    {
        paused = true;
        gameWon.SetActive(true);
        Time.timeScale = 0f;
        //CheckBestTime();
        Cursor.lockState = CursorLockMode.None;

        if (PlayerPrefs.GetFloat("Time") > TimeCounter.time)
        {
            PlayerPrefs.SetFloat("Time", TimeCounter.time);
        }
        
        Debug.Log("Salvato: "+PlayerPrefs.GetFloat("Time")+ "Attuale: "+TimeCounter.time);
        
        timeText.text = "YOUR TIME: " + TimeCounter.minutes.ToString("00") + ":" + TimeCounter.seconds.ToString("00") + ":" + TimeCounter.milliseconds.ToString("00");
        bestTimeText.text = "BEST TIME: " + TimeCounter.bMinutes.ToString("00") + ":" + TimeCounter.bSeconds.ToString("00") + ":" + TimeCounter.bMilliseconds.ToString("00");

        //bestTimeText.text = "BEST TIME: " + TimeCounter.bMinutes.ToString("00") + ":" + TimeCounter.bSeconds.ToString("00") + ":" + TimeCounter.bMilliseconds.ToString("00");
    }
    
    public void GameQuit() 
    {
        SceneManager.LoadSceneAsync(0);
    }
    
   
}
