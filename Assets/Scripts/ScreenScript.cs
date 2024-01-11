using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScript : MonoBehaviour
{
    public GameObject endMenu;

    void Start()
    {
        endMenu.SetActive(false);
    }

    void Update()
    {
        /*
        if (!alive)
        {
            endMenu.SetActive(false);
        } 
        */
    }
}
