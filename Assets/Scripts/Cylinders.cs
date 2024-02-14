using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinders : MonoBehaviour
{ 
    public GameObject cylinder;

    GameObject spawnedCylinder;
    float potenza = 10;
    float reload = 1f;
    
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time >= reload)
        {
            spawnedCylinder = Instantiate(cylinder, new Vector3(9, 2.5f, 9) + Vector3.left, Quaternion.Euler(270, 0, 0));
            spawnedCylinder.GetComponent<Rigidbody>().velocity = Vector3.left * this.potenza;
            //spawnedCylinder.GetComponent<Rigidbody>().useGravity = Vector3.left * this.potenza;
            reload = Time.time + 1f;
        } 
    }
}


