using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinalLayer : MonoBehaviour
{
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
        
    }
}
