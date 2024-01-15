using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public static float time = 0;
    public static float bestTime = 0;

    public static int minutes;
    public static int seconds;
    public static int milliseconds;
    
    public static int bMinutes=0;
    public static int bSeconds=0;
    public static int bMilliseconds=0;

    private bool playing;

    void Start()
    {
        time = 0;
        playing = true;
        
       /* if (PlayerPrefs.GetFloat("Time", 0) == 0)
        {
            PlayerPrefs.SetFloat("Time", 0);
            bestTime = 0;
            Debug.Log("RESET____________________");
        }
        else
        {
        }
        */
        bestTime = PlayerPrefs.GetFloat("Time");
        Debug.Log(+bestTime);
        bMinutes = Mathf.FloorToInt(bestTime / 60f);
        bSeconds = Mathf.FloorToInt(bestTime % 60f);
        bMilliseconds = Mathf.FloorToInt((bestTime * 00f) % 100f);
    }
    
    private void OnEnable()
    {
        playing = true;
    }

    void Update()
    {
        //bestTime += Time.deltaTime;

        if (playing)
        {
            time += Time.deltaTime;
            minutes = Mathf.FloorToInt(time / 60f);
            seconds = Mathf.FloorToInt(time % 60f);
            milliseconds = Mathf.FloorToInt((time * 100f) % 100f);
        }
    }
}
