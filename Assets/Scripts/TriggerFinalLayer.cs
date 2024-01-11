using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinalLayer : MonoBehaviour
{

    private bool alive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    { 
        if (collision.gameObject.name.Contains("Cylinder"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Contains("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Contains("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Contains("ThirdPersonPlayer"))
        {
            alive = false;
            Destroy(collision.gameObject);
        }
    }
}
